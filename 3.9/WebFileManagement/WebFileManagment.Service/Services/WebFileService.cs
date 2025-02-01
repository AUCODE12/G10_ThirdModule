using WebFileManagement.StorageBroker.Services;

namespace WebFileManagment.Service.Services;

public class WebFileService : IWebFileService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public WebFileService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public async Task CreateFolderAsync(string directoryPath)
    {
        await _storageBrokerService.CreateFolderAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await _storageBrokerService.DeleteFileAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await _storageBrokerService.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadDirectoryZipAsync(string directoryPath)
    {
        return await _storageBrokerService.DownloadDirectoryZipAsync(directoryPath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        return await _storageBrokerService.DownloadFileAsync(filePath);
    }

    public async Task<List<string>> GetFilesAndDirectoriesAsync(string directoryPath)
    {
        return await _storageBrokerService.GetFilesAndDirectoriesAsync(directoryPath);
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await _storageBrokerService.UploadFileAsync(filePath, stream);
    }
}
