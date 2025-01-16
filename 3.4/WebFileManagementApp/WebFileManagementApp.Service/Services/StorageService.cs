using WebFileManagementApp.StorageBroker.Services;

namespace WebFileManagementApp.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectorInDataBase(string directoryPath)
    {
        _storageBrokerService.CreateDirectorInDataBase(directoryPath);
    }

    public void DeleteFile(string fileName)
    {
        _storageBrokerService.DeleteFile(fileName);
    }

    public bool DirectoryExists(string directoryPath)
    {
        return _storageBrokerService.DirectoryExists(directoryPath);
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBrokerService.DownloadFile(filePath);
    }

    public bool FileExists(string filePath)
    {
        return _storageBrokerService.FileExists(filePath);
    }

    public List<string> GetAllDirectories()
    {
        return _storageBrokerService.GetAllDirectories(); 
    }

    public List<string> GetAllFiles()
    {
        return _storageBrokerService.GetAllFiles();
    }

    public void UploadFile(Stream fileStream, string filePath)
    {
        _storageBrokerService.UploadFile(fileStream, filePath);
    }
}
