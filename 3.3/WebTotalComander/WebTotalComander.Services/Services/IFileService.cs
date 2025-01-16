using WebTotalComander.DataAccess.Entities;
using WebTotalComander.Services.DTOs;

namespace WebTotalComander.Services.Services;

public interface IFileService
{
    Guid AddFile(StorageFileDto fileDto);

    List<StorageFileDto> GetAllFiles();

    StorageFileDto GetFileById(Guid id);

    void DeleteFile(Guid id);

    void UpgradeFile(StorageFileDto updatedFileDto);

    //

    void GetAllFilesByDirectoryLocation(string location);

    ///
    public void SendAuthCodeTg(string phoneNumber);

}