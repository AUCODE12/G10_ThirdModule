using WebFileManagementSystem.StorageBroker.Services;

namespace WebFileManagementSystem.Service.Services;

public class StorageService : IStorageService
{
    private IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
         _storageBrokerService = storageBrokerService;
    }

    public void DeleteFile(string filePath)
    {
        _storageBrokerService.DeleteFile(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBrokerService.DownloadFile(filePath);
    }

    public List<string> GetAllFiles()
    {
        return _storageBrokerService.GetAllFiles();
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBrokerService.UploadFile(filePath, stream);
    }
}
