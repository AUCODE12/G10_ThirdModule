namespace WebTotalComander.Services.DTOs;

public class StorageFileDto
{
    public Guid? Id { get; set; }                // Fayl ID'si
    public string Name { get; set; }           // Fayl nomi
    public string Extension { get; set; }      // Fayl kengaytmasi (masalan, .txt, .jpg)
    public long Size { get; set; }             // Fayl o‘lchami (baytlarda)
    public DateTime UploadedAt { get; set; }   // Yuklangan vaqti
    public string FilePath { get; set; }       // Serverdagi to‘liq yo‘li

    public string FileUploadPath { get; set; } // Serverga filening kelayotgan yo'li
}
