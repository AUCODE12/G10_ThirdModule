using FileManagement.StorageBroker.Services;

namespace FileManagement.Service.Services;

public class FileManagementService : IFileManagementService
{
    private readonly IStorageBorkerService _storageBorkerService;

    public FileManagementService(IStorageBorkerService storageBorkerService)
    {
         _storageBorkerService = storageBorkerService;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await _storageBorkerService.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await _storageBorkerService.DeleteDirectoryAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await _storageBorkerService.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadDirectoryAsync(string directoryPath)
    {
        return await _storageBorkerService.DownloadDirectoryAsync(directoryPath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        return await _storageBorkerService.DownloadFileAsync(filePath);
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        return await _storageBorkerService.GetAllFilesAndDirectoriesAsync(directoryPath);
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await _storageBorkerService.UploadFileAsync(filePath, stream);
    }
}
