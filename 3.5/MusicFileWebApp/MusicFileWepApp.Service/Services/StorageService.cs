using MusicFileWebApp.StorageBroker.Services;

namespace MusicFileWebApp.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string? directoryPath, string directoryName)
    {
        directoryPath = directoryPath ?? string.Empty;
        _storageBrokerService.CreateDirectory(directoryPath, directoryName);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _storageBrokerService.DeleteDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        _storageBrokerService.DeleteFile(filePath);
    }

    public Stream DownloadDirectory(string directoryPath)
    {
        return _storageBrokerService.DownloadDirectory(directoryPath);
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBrokerService.DownloadFile(filePath);
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        return _storageBrokerService.GetAllFilesAndDirectories(directoryPath);
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBrokerService.UploadFile(filePath, stream);
    }
}
