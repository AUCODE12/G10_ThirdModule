
namespace WebFileManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if(!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }


    public async Task CreateFolderAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
       

        if (Directory.Exists(directoryPath))
        {
            throw new Exception("THIS directory already created");
        }
        var getParent = Directory.GetParent(directoryPath);

        if(!Directory.Exists(getParent.FullName))
        {
            throw new Exception("not found parent path");
        }

        Directory.CreateDirectory(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath,directoryPath);

        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("not found");
        }
        Directory.Delete(directoryPath,true);

    }

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath,filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("not found");
        }
            File.Delete(filePath);
    }

    public Task<Stream> DownloadDirectoryZipAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath= Path.Combine(_dataPath,filePath);
        if(!File.Exists(filePath))
        {
            throw new Exception("not found");
        }
        var stream = new FileStream(filePath,FileMode.Open,FileAccess.Read);
        return stream;
    }

    public async Task<List<string>> GetFilesAndDirectoriesAsync(string directoryPath)
    {
        directoryPath= Path.Combine(_dataPath,directoryPath);

        if(!Directory.Exists(directoryPath))
        {
            throw new Exception("not found");
        }
        var parent = Directory.GetParent(directoryPath);
        if(!Directory.Exists(parent.FullName))
        {
            throw new Exception("not found");
        }

        var getAll = Directory.GetFileSystemEntries(directoryPath).ToList();

        return getAll;

    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath,filePath);    
        var parentPath = Directory.GetParent(filePath);
        if(!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("not found parent path");

        }
        using(var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
           await stream.CopyToAsync(fileStream);
        }
    }
}
