namespace WebFileManagementSystem.Service.Services;

public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);

    Stream DownloadFile(string filePath);

    List<string> GetAllFiles();

    void DeleteFile(string filePath);
}