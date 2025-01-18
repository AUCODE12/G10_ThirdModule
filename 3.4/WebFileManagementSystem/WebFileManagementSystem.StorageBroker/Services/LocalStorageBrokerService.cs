
namespace WebFileManagementSystem.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _localDataBasePath;

    public LocalStorageBrokerService()
    {
        _localDataBasePath = Path.Combine(Directory.GetCurrentDirectory(), "localDataBase");

        if (!Directory.Exists(_localDataBasePath))
        {
            Directory.CreateDirectory(_localDataBasePath);
        }
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_localDataBasePath, filePath);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        File.Delete(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_localDataBasePath, filePath);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    public List<string> GetAllFiles()
    {
        return Directory.GetFiles(_localDataBasePath).ToList();
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_localDataBasePath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("not found");
        }
        
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);//, 1024 * 1024 * 100
        }
        
    }
}
