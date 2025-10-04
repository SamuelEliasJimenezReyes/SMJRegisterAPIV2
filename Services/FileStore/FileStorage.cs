using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

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

                var creds = new BasicAWSCredentials(accessKey, secretKey);
                var s3Config = new AmazonS3Config
                {
                    ServiceURL = $"https://{_accountId}.r2.cloudflarestorage.com",
                    ForcePathStyle = true,
                    AuthenticationRegion = "auto",
                    UseHttp = true,
                    BufferSize = 8192,
                    MaxErrorRetry = 2,
                    Timeout = TimeSpan.FromSeconds(100)
                    // ReadWriteTimeout no existe - eliminado
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
            var keys = await MultipleStore(container, folderName, new[] { file });
            return keys[0];
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
            var result = new List<string>();

            foreach (var file in files)
            {
                var original = Path.GetFileNameWithoutExtension(file.FileName)!.ToLower().Trim().Replace(" ", "-");
                var ext = Path.GetExtension(file.FileName);
                var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
                var name = $"{original}_{timestamp}{ext}";
                var key = $"{container}/{folderName}/{name}".Replace("\\", "/");

                try
                {
                    await using var stream = file.OpenReadStream();

                    var putRequest = new PutObjectRequest
                    {
                        BucketName = _bucket!,
                        Key = key,
                        InputStream = stream,
                        ContentType = file.ContentType,
                        CannedACL = S3CannedACL.Private,
                        DisablePayloadSigning = true,
                        UseChunkEncoding = false
                    };

                    var response = await _s3Client.PutObjectAsync(putRequest);
                    result.Add(key);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading to R2 - Key: {key}, ContentType: {file.ContentType}");
                    Console.WriteLine($"Exception: {ex.Message}");
                    if (ex.InnerException != null)
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    throw;
                }
            }

            return result;
        }

        public async Task<string> RenameFileIfExists(string container, string folderName, IFormFile file)
            => await Store(container, folderName, file);

        public async Task Delete(string? keyOrPath, string container)
        {
            if (string.IsNullOrWhiteSpace(keyOrPath)) return;

            if (_useR2)
            {
                if (_s3Client == null) return;
                try
                {
                    await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
                    {
                        BucketName = _bucket,
                        Key = keyOrPath
                    });
                }
                catch (AmazonS3Exception aex) when (aex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                }
            }
            else
            {
                var fileName = Path.GetFileName(keyOrPath);
                var filePath = Path.Combine(_env.WebRootPath!, container, fileName);
                if (File.Exists(filePath)) File.Delete(filePath);
            }
        }

        public string GetSignedUrl(string key, int minutes = 1440)
        {
            if (_s3Client == null) throw new InvalidOperationException("S3 client no inicializado");

            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucket!,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                Verb = HttpVerb.GET
            };

            return _s3Client.GetPreSignedURL(request);
        }

        public bool IsKey(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
        
            return !input.StartsWith("http") && !input.Contains("cloudflarestorage.com");
        }

        public string ExtractKeyFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
        
            try
            {
                var uri = new Uri(url);
                var path = uri.AbsolutePath;
                return path.TrimStart('/');
            }
            catch
            {
                return url;
            }
        }
    }
}