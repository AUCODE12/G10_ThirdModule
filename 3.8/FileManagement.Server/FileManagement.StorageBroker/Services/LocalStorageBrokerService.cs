
using System.IO.Compression;

namespace FileManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBorkerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");

        if (!Directory.Exists(_dataPath)) Directory.CreateDirectory(_dataPath);
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (Directory.Exists(directoryPath)) throw new Exception();
        var parent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parent.FullName)) throw new Exception(); 
        //aweit
        Directory.CreateDirectory(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (!Directory.Exists(directoryPath)) throw new Exception();
        
        Directory.Delete(directoryPath, true);
    }

    public async Task<Stream> DownloadDirectoryAsync(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty) throw new Exception("DirectoryPath is not directory");
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath)) throw new Exception();

        var zipPath = directoryPath + ".zip";
        
        ZipFile.CreateFromDirectory(directoryPath, zipPath);

        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);

        return stream;
    }

    //
    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath)) throw new Exception();
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath)) throw new Exception();
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);

        if (!Directory.Exists(parentPath.FullName)) throw new Exception();

        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
    }

    //
    public List<string> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath ,directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if(!Directory.Exists(parentPath.FullName)) throw new Exception();

        var allFilesAndDirectories = Directory.GetFileSystemEntries(directoryPath).ToList();
        allFilesAndDirectories = allFilesAndDirectories.Select(a => a.Remove(0, directoryPath.Length + 1)).ToList();
        return allFilesAndDirectories;
    }
}
