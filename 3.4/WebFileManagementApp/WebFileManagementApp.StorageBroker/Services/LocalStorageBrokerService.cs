using System.Linq;

namespace WebFileManagementApp.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;

    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data Base");

        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public void CreateDirectorInDataBase(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already created");
        }
        var hasParent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(hasParent.FullName))
        {
            throw new Exception($"{directoryPath}: folder not found");
        }
        Directory.CreateDirectory(directoryPath);
    }


    public void DeleteFile(string fileName)
    {
        fileName = Path.Combine(_dataPath, fileName);
        if (File.Exists(fileName))
        {
            throw new Exception("Folder has already created");
        }
        File.Delete(fileName);   
    }

    public bool DirectoryExists(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        return Directory.Exists(directoryPath);
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if(!Path.Exists(filePath))
        {
            throw new Exception($"{filePath}: not found");
        }
        return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    }

    public bool FileExists(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        return File.Exists(filePath);
    }

    public List<string> GetAllDirectories()
    {
        return Directory.GetDirectories(_dataPath).Select(d => d.Remove(0, _dataPath.Length + 1)).ToList();
    }

    public List<string> GetAllFiles()
    {
        return Directory.GetFiles(_dataPath, "*", SearchOption.AllDirectories).Select(f => f.Remove(0, _dataPath.Length + 1)).ToList();
    }

    public void UploadFile(Stream fileStream, string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder not found");
        }

        using (var destinationStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            fileStream.CopyTo(destinationStream);
        }
    }

    public Stream CompressDirectory(string directoryPath)
    {
        var memoryStream = new MemoryStream();

        using (var archive = new System.IO.Compression.ZipArchive(memoryStream, System.IO.Compression.ZipArchiveMode.Create, true))
        {
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(directoryPath, file);
                var entry = archive.CreateEntry(relativePath, System.IO.Compression.CompressionLevel.Fastest);

                using (var entryStream = entry.Open())
                using (var fileStream = System.IO.File.OpenRead(file))
                {
                    fileStream.CopyTo(entryStream);
                }
            }
        }

        memoryStream.Position = 0; // Streamni boshidan o‘qing
        return memoryStream;
    }

}
