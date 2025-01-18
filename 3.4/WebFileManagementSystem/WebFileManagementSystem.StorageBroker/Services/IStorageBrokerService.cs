using WebFileManagementSystem.DataAccess.Entities;

namespace WebFileManagementSystem.StorageBroker.Services;

public interface IStorageBrokerService
{ 
    void UploadFile(string filePath, Stream stream);

    Stream DownloadFile(string filePath);

    List<string> GetAllFiles();

    void DeleteFile(string filePath);
}
