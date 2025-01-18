namespace WebFileManagementSystem.DataAccess.Entities;

public class StorageFile
{
    public Guid Id { get; set; }

    public string FileName { get; set; }

    public long FileSize { get; set; }

    public string FilePath { get; set; }

    public string FileExtension { get; set; }
}
