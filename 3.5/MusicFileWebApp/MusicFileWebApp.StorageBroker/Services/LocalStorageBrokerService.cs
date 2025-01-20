
using System.IO.Compression;

namespace MusicFileWebApp.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _data;

    public LocalStorageBrokerService()
    {
        _data = Path.Combine(Directory.GetCurrentDirectory(), "data");
        
        if (!Directory.Exists(_data))
        {
            Directory.CreateDirectory(_data);
        }
    }

    public void CreateDirectory(string? directoryPath, string directoryName)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(_data, directoryPath);
        directoryName = Path.Combine(directoryPath, directoryName);
        if (Directory.Exists(directoryName))
        {
            throw new Exception("Folder has already created");
        }
        var parentPath = Directory.GetParent(directoryName);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception($"{directoryPath} already exists");
        }
        
        Directory.CreateDirectory(directoryName);
    }

    public void DeleteDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_data, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception();
        }
        Directory.Delete(directoryPath, true);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_data, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("file not found");
        }

        File.Delete(filePath);
    }

    public Stream DownloadDirectory(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
        {
            throw new Exception();
        }
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception();
        }
        directoryPath = Path.Combine(_data, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception();
        }

        var zip = directoryPath + ".zip";

        ZipFile.CreateFromDirectory(directoryPath, zip);
        return new FileStream(zip, FileMode.Open, FileAccess.Read);
    }

    public Stream DownloadFile(string filePath)
    {
        if(string.IsNullOrEmpty(filePath))
        {
            throw new Exception();
        }

        filePath = Path.Combine(_data, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("file not found");
        }

        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_data, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception();
        }

        return Directory.GetFileSystemEntries(directoryPath).Select(f => f.Remove(0, directoryPath.Length + 1)).ToList();
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_data, filePath);
        
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }

        var bytes = 1024 * 1024 * 100;
        byte[] buffer = new byte[bytes];
        int bytesRead;

        using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            while(true)
            {
                bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                if (bytesRead <= 0) break;

                stream.CopyTo(fileStream, bytesRead);
            }
        }
    }
}
