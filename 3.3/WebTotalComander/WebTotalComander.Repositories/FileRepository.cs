using System.Text.Json;
using WebTotalComander.DataAccess.Entities;

namespace WebTotalComander.Repositories;

public class FileRepository : IFileRepository
{
    private readonly string _pathBaseDirectory; 
    private readonly string _fileBase;
    private readonly List<StorageFile> _storageFiles;

    public FileRepository()
    {
        _pathBaseDirectory = @"d:\my_app";
        _fileBase = Path.Combine(_pathBaseDirectory, "Files.json");
        if (!Directory.Exists(_pathBaseDirectory))
        {
            Directory.CreateDirectory(_pathBaseDirectory);
        }
        if (!File.Exists(_fileBase))
        {
            File.WriteAllText(_fileBase, "[]");
        }

        _storageFiles = ReadAllFiles();
    }

    public void DeleteFile(Guid id)
    {
        var file = ReadFileById(id);
        _storageFiles.Remove(file);
        SaveData();
    }

    public List<StorageFile> ReadAllFiles()
    {
        var filesJson = File.ReadAllText(_fileBase);
        var filesList = JsonSerializer.Deserialize<List<StorageFile>>(filesJson);
        return filesList;
    }

    public StorageFile ReadFileById(Guid id)
    {
        var file = _storageFiles.FirstOrDefault(sf => sf.Id == id);
        if (file == null)
        {
            throw new NullReferenceException($"{id}: this is not");
        }
        return file;
    }

    public void UpgradeFile(StorageFile updatedFile)
    {
        var file = ReadFileById(updatedFile.Id);
        var index = _storageFiles.IndexOf(file);
        _storageFiles[index] = updatedFile;
        SaveData();
    }

    public Guid WriteFile(StorageFile storageFile)
    {
        _storageFiles.Add(storageFile);
        SaveData();
        return storageFile.Id;
    }

    private void SaveData()
    {
        var filesJson = JsonSerializer.Serialize(_storageFiles);
        File.WriteAllText(_fileBase, filesJson);
    }
}
