namespace WebFileManagementSystem.StorageBroker.DTOs;

public class StorageFileDto
{
    public Guid? Id { get; set; }

    public string FileName { get; set; }

    public long FileSize { get; set; }

    public string FilePath { get; set; }

    public string FileExtension { get; set; }
}
