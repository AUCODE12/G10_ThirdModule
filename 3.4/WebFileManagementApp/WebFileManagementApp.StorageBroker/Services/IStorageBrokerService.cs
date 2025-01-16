namespace WebFileManagementApp.StorageBroker.Services;

public interface IStorageBrokerService
{
    /// <summary>
    /// Fayl yuklash
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="filePath"></param>
    void UploadFile(Stream fileStream, string filePath);

    /// <summary>
    /// Faylni yuklab olish
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    Stream DownloadFile(string filePath);

    /// <summary>
    /// Faylni o‘chirish
    /// </summary>
    /// <param name="fileName"></param>
    void DeleteFile(string fileName);

    /// <summary>
    /// Data Base ichiga folder yaratish
    /// </summary>
    /// <param name="directoryPath"></param>
    void CreateDirectorInDataBase(string directoryPath);

    /// <summary>
    /// Folder mavjudligini tekshirish
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <returns></returns>    
    bool DirectoryExists(string directoryPath);

    /// <summary>
    /// Fayl mavjudligini tekshirish
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    bool FileExists(string filePath);

    /// <summary>
    /// Hamma fayllarni ro‘yxatini olish
    /// </summary>
    /// <returns></returns>
    List<string> GetAllFiles();

    /// <summary>
    /// Hamma folderlarni ro‘yxatini olish
    /// </summary>
    /// <returns></returns>
    List<string> GetAllDirectories();


    //Stream CompressDirectory(string directoryPath);

}
