using System.Text.Json;
using WebTotalComander.DataAccess.Entities;
using WebTotalComander.Repositories;
using WebTotalComander.Services.DTOs;

namespace WebTotalComander.Services.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    //
    private readonly string _filesInLocation;
    FileInfo fileInfo;
    public FileService()
    {
        _fileRepository = new FileRepository();
        //
        _filesInLocation = Path.Combine(Directory.GetCurrentDirectory(), "GetFiles.json");
        if (!File.Exists(_filesInLocation))
        {
            File.WriteAllText(_filesInLocation, "");
        }
        fileInfo = new FileInfo(_filesInLocation);

    }

    public Guid AddFile(StorageFileDto fileDto)
    {
        return _fileRepository.WriteFile(ConvertToStorageFile(fileDto));
    }

    public void DeleteFile(Guid id)
    {
        _fileRepository.DeleteFile(id);
    }

    public List<StorageFileDto> GetAllFiles()
    {
        return _fileRepository.ReadAllFiles().Select(f => ConvertToDto(f)).ToList();
    }

    //
    public void GetAllFilesByDirectoryLocation(string location)
    {
        var filesName = Directory.GetFiles(location, "*", SearchOption.AllDirectories);
        using (StreamWriter writer = new StreamWriter(_filesInLocation, append: true))
        {
            var filesNameJson = JsonSerializer.Serialize(filesName);
            writer.WriteLine(filesNameJson);
        }
    }

    public StorageFileDto GetFileById(Guid id)
    {
        return ConvertToDto(_fileRepository.ReadFileById(id));
    }

    public void UpgradeFile(StorageFileDto updatedFileDto)
    {
        _fileRepository.UpgradeFile(ConvertToStorageFile(updatedFileDto));
    }


    ///
    public void SendAuthCodeTg(string phoneNumber)
    {

    }

    private StorageFile ConvertToStorageFile(StorageFileDto storageFileDto)
    {
        return new StorageFile
        {
            Extension = storageFileDto.Extension,
            FilePath = storageFileDto.FilePath,
            FileUploadPath = storageFileDto.FilePath,
            Name = storageFileDto.Name,
            Size = storageFileDto.Size,
            UploadedAt = storageFileDto.UploadedAt,
            Id = storageFileDto.Id ?? Guid.NewGuid(),
        };
    }

    private StorageFileDto ConvertToDto(StorageFile storageFile)
    {
        return new StorageFileDto
        {
            Extension = storageFile.Extension,
            FilePath = storageFile.FilePath,
            UploadedAt = storageFile.UploadedAt,
            Id = storageFile.Id,
            Name = storageFile.Name,
            Size = storageFile.Size,
            FileUploadPath = storageFile.FilePath,
        };
    }
}
