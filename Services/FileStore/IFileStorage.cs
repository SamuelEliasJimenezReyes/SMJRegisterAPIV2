namespace SMJRegisterAPI.Services.FileStore;

public interface IFileStorage
{
    Task Delete(string? path, string container);

    Task<string> Store(string container, string folderName, IFormFile file);

    Task<string> RenameFileIfExists(string container, string folderName, IFormFile file);

    async Task<string> Edit(string path, string container, string folderName, IFormFile file)
    {
        await Delete(path, container);
        return await Store(container, folderName, file);
    }
    Task<List<string>> MultipleStore(string container, string folderName, IEnumerable<IFormFile> files);
}