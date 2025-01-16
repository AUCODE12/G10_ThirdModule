using WebTotalComander.DataAccess.Entities;

namespace WebTotalComander.Repositories;

public interface IFileRepository
{
    Guid WriteFile(StorageFile storageFile);

    List<StorageFile> ReadAllFiles();

    StorageFile ReadFileById(Guid id);

    void DeleteFile(Guid id);

    void UpgradeFile(StorageFile updatedFile);
}