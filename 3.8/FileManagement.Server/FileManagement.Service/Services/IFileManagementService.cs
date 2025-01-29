namespace FileManagement.Service.Services;

public interface IFileManagementService
{
    Task UploadFileAsync(string filePath, Stream stream);

    Task DeleteFileAsync(string filePath);

    Task<Stream> DownloadFileAsync(string filePath);

    Task CreateDirectoryAsync(string directoryPath);

    Task DeleteDirectoryAsync(string directoryPath);

    Task<Stream> DownloadDirectoryAsync(string directoryPath);

    //List<string> GetDirectoriesAsync();

    //List<string> GetFilesAsync();

    Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath);
}