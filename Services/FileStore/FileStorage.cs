using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SMJRegisterAPIV2.Services.FileStore
{
    public class FileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly bool _useR2;
        private readonly IAmazonS3? _s3Client;
        private readonly string? _bucket;
        private readonly string? _accountId;
        private readonly bool _publicObjects;
        private readonly int _signedUrlMinutes;

        public FileStorage(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;

            _useR2 = string.Equals(Environment.GetEnvironmentVariable("USE_R2"), "true", StringComparison.OrdinalIgnoreCase);
            if (_useR2)
            {
                _accountId = Environment.GetEnvironmentVariable("R2_ACCOUNT_ID") ?? throw new ArgumentNullException("R2_ACCOUNT_ID");
                var accessKey = Environment.GetEnvironmentVariable("R2_ACCESS_KEY_ID") ?? throw new ArgumentNullException("R2_ACCESS_KEY_ID");
                var secretKey = Environment.GetEnvironmentVariable("R2_SECRET_ACCESS_KEY") ?? throw new ArgumentNullException("R2_SECRET_ACCESS_KEY");
                _bucket = Environment.GetEnvironmentVariable("R2_BUCKET") ?? throw new ArgumentNullException("R2_BUCKET");
                _publicObjects = string.Equals(Environment.GetEnvironmentVariable("R2_PUBLIC"), "true", StringComparison.OrdinalIgnoreCase);
                _signedUrlMinutes = int.TryParse(Environment.GetEnvironmentVariable("SIGNED_URL_MINUTES"), out var m) ? m : 60;

                var creds = new BasicAWSCredentials(accessKey, secretKey);
                var s3Config = new AmazonS3Config
                {
                    ServiceURL = $"https://{_accountId}.r2.cloudflarestorage.com",
                    ForcePathStyle = true,
                };
                _s3Client = new AmazonS3Client(creds, s3Config);

            }
            else
            {
                _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
        }

        public async Task<string> Store(string container, string folderName, IFormFile file)
        {
            var urls = await MultipleStore(container, folderName, new[] { file });
            return urls[0];
        }

        public async Task<List<string>> MultipleStore(string container, string folderName, IEnumerable<IFormFile> files)
        {
            return _useR2 ? await MultipleStoreToR2(container, folderName, files) : await MultipleStoreToLocal(container, folderName, files);
        }

        private async Task<List<string>> MultipleStoreToLocal(string container, string folderName, IEnumerable<IFormFile> files)
        {
            var folderPath = Path.Combine(_env.WebRootPath!, container, folderName);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            var result = new List<string>();
            foreach (var file in files)
            {
                var original = Path.GetFileNameWithoutExtension(file.FileName)!.ToLower().Trim().Replace(" ", "-");
                var ext = Path.GetExtension(file.FileName);
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var name = $"{original}_{timestamp}{ext}";
                var path = Path.Combine(folderPath, name);

                await using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                await File.WriteAllBytesAsync(path, ms.ToArray());

                var url = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext!.Request.Host}";
                result.Add(Path.Combine(url, container, folderName, name).Replace("\\", "/"));
            }
            return result;
        }

        private async Task<List<string>> MultipleStoreToR2(string container, string folderName, IEnumerable<IFormFile> files)
        {
            if (_s3Client == null) throw new InvalidOperationException("S3 client no inicializado");
            var transferUtil = new TransferUtility(_s3Client);
            var result = new List<string>();

            foreach (var file in files)
            {
                var original = Path.GetFileNameWithoutExtension(file.FileName)!.ToLower().Trim().Replace(" ", "-");
                var ext = Path.GetExtension(file.FileName);
                var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
                var name = $"{original}_{timestamp}{ext}";
                var key = $"{container}/{folderName}/{name}".Replace("\\", "/");

                await using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                ms.Position = 0;

                var uploadReq = new TransferUtilityUploadRequest
                {
                    InputStream = ms,
                    BucketName = _bucket!,
                    Key = key,
                    ContentType = file.ContentType
                };

                try
                {
                    var reqType = uploadReq.GetType();

                    var p1 = reqType.GetProperty("DisablePayloadSigning");
                    if (p1 != null && p1.CanWrite)
                        p1.SetValue(uploadReq, true);

                    var p2 = reqType.GetProperty("DisableDefaultChecksumValidation");
                    if (p2 != null && p2.CanWrite)
                        p2.SetValue(uploadReq, true);
                }
                catch
                {
                }

                if (_publicObjects)
                    uploadReq.CannedACL = S3CannedACL.PublicRead;

                await transferUtil.UploadAsync(uploadReq);

                if (_publicObjects)
                {
                    var publicUrl = $"https://{_accountId}.r2.cloudflarestorage.com/{_bucket}/{Uri.EscapeDataString(key)}";
                    result.Add(publicUrl);
                }
                else
                {
                    var preReq = new GetPreSignedUrlRequest
                    {
                        BucketName = _bucket!,
                        Key = key,
                        Verb = HttpVerb.GET,
                        Expires = DateTime.UtcNow.AddMinutes(_signedUrlMinutes)
                    };
                    var url = _s3Client.GetPreSignedURL(preReq);
                    result.Add(url);
                }
            }

            return result;
        }

        public async Task<string> RenameFileIfExists(string container, string folderName, IFormFile file)
            => await Store(container, folderName, file);

        public async Task Delete(string? path, string container)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            if (_useR2)
            {
                if (_s3Client == null) return;
                string key;

                var r2Marker = $"{_accountId}.r2.cloudflarestorage.com/";
                if (path.Contains(r2Marker))
                {
                    var idx = path.IndexOf(r2Marker) + r2Marker.Length;
                    var after = path.Substring(idx); // starts with {bucket}/...
                    var slash = after.IndexOf('/');
                    key = slash >= 0 ? Uri.UnescapeDataString(after.Substring(slash + 1)) : Uri.UnescapeDataString(after);
                }
                else if (path.Contains(".s3.amazonaws.com/"))
                {
                    var idx = path.IndexOf(".s3.amazonaws.com/") + ".s3.amazonaws.com/".Length;
                    key = Uri.UnescapeDataString(path.Substring(idx));
                }
                else
                {
                    if (path.Contains($"/{container}/"))
                    {
                        var idx = path.IndexOf($"/{container}/") + 1; // index at container/...
                        key = Uri.UnescapeDataString(path.Substring(idx));
                    }
                    else
                    {
                        var fileName = Path.GetFileName(path);
                        key = $"{container}/{fileName}";
                    }
                }

                try
                {
                    await _s3Client.DeleteObjectAsync(new DeleteObjectRequest { BucketName = _bucket, Key = key });
                }
                catch (AmazonS3Exception aex) when (aex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                }
            }
            else
            {
                var fileName = Path.GetFileName(path);
                var filePath = Path.Combine(_env.WebRootPath!, container, fileName);
                if (File.Exists(filePath)) File.Delete(filePath);
            }
        }
    }
}
