namespace WebFileManagement.StorageBroker.Services;

public interface IStorageBrokerService
{
    Task UploadFileAsync(string filePath, Stream stream);

    Task CreateFolderAsync(string directoryPath);

    Task DeleteDirectoryAsync(string directoryPath);

    Task DeleteFileAsync(string filePath);

    Task<Stream> DownloadFileAsync(string filePath);

    Task<Stream> DownloadDirectoryZipAsync(string directoryPath);

    Task<List<string>> GetFilesAndDirectoriesAsync(string directoryPath);
}
