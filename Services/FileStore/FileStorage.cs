namespace SMJRegisterAPI.Services.FileStore;

public class FileStorage (IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor) : IFileStorage
{
    public async Task<string> Store(string container, string folderName, IFormFile file)
    {
        var urls = await MultipleStore(container, folderName, new[] { file });
        return urls.First();
    }

    public async Task<List<string>> MultipleStore(string container, string folderName, IEnumerable<IFormFile> files)
    {
        env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var folderPath = Path.Combine(env.WebRootPath, container, folderName);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var uploadTasks = files.Select(async file =>
        {
            var originalFileName = Path.GetFileNameWithoutExtension(file.FileName.ToLower().Trim()).Replace(" ", "-");
            var extension = Path.GetExtension(file.FileName);
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"{originalFileName}_{timestamp}{extension}";
            var path = Path.Combine(folderPath, fileName);

            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            await File.WriteAllBytesAsync(path, ms.ToArray());

            var url = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";
            return Path.Combine(url, container, folderName, fileName).Replace("\\", "/");
        });

        var result = await Task.WhenAll(uploadTasks);
        return result.ToList();
    }

    public async Task<string> RenameFileIfExists(string container, string folderName, IFormFile file)
    {
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var extension = Path.GetExtension(file.FileName);
        var nameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName).Replace("_", " ");
        var newFileName = $"{nameWithoutExt}_{timestamp}{extension}";

        env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var folder = Path.Combine(env.WebRootPath, container, folderName);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var path = Path.Combine(folder, newFileName);

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        await File.WriteAllBytesAsync(path, ms.ToArray());

        var url = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";
        return Path.Combine(url, container, folderName, newFileName).Replace("\\", "/");
    }

    public Task Delete(string? path, string container)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Task.CompletedTask;

        var fileName = Path.GetFileName(path);
        var filePath = Path.Combine(env.WebRootPath, container, fileName);

        if (File.Exists(filePath))
            File.Delete(filePath);

        return Task.CompletedTask;
    }
}