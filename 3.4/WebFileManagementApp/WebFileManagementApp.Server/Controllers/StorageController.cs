using Microsoft.AspNetCore.Mvc;
using WebFileManagementApp.Service.Services;

namespace WebFileManagementApp.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class StorageController : ControllerBase
{
    private IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
         _storageService = storageService;
    }

    [HttpPost("uploadFile")]
    public void UploadFile(IFormFile file, string filePath)
    {
        filePath = Path.Combine(filePath, file.FileName);

        using (var stream = file.OpenReadStream())
        {
            _storageService.UploadFile(stream, filePath);
        }
    }

    [HttpGet("downloadFile")]
    public IActionResult DownloadFile(string filePath)
    {
        try
        {
            if (_storageService.DirectoryExists(filePath))
            {
                // Katalogni ZIP qilish
                var zipStream = _storageService.CompressDirectory(filePath);

                // ZIP fayl nomini aniqlash
                var zipFileName = $"{Path.GetFileName(filePath)}.zip";

                return File(zipStream, "application/zip", zipFileName);
            }
            else if (_storageService.FileExists(filePath))
            {
                // Fayl oqimini olish
                var fileStream = _storageService.DownloadFile(filePath);

                // Fayl nomini aniqlash
                var fileName = Path.GetFileName(filePath);

                return File(fileStream, "application/octet-stream", fileName);
            }
            else
            {
                return NotFound($"Fayl yoki katalog topilmadi: {filePath}");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Xatolik yuz berdi: {ex.Message}");
        }
    }

    [HttpDelete("deleteFile")]
    public void DeleteFile(string fileName)
    {
        _storageService.DeleteFile(fileName);
    }

    [HttpPost("createDirectory")]
    public void CreateDirectorInDataBase(string directoryPath)
    {
        _storageService.CreateDirectorInDataBase(directoryPath);
    }

    [HttpGet("directoryExists")]
    public bool DirectoryExists(string directoryPath)
    {
        return _storageService.DirectoryExists(directoryPath);
    }

    [HttpGet("fileExists")]
    public bool FileExists(string filePath)
    {
        return FileExists(filePath);
    }

    [HttpGet("getAllFiles")]    
    public List<string> GetAllFiles()
    {
        return _storageService.GetAllFiles();
    }

    [HttpGet("getAllDirectories")]
    public List<string> GetAllDirectories()
    { 
        return _storageService.GetAllDirectories(); 
    }
}