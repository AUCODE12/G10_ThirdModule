using Microsoft.AspNetCore.Mvc;
using MusicFileWebApp.Service.Services;
using System.IO;

namespace MusicFileWebApp.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost("uploadFile")]
    public void UploadFile(IFormFile file, string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.FileName);
        
        using (var stream = file.OpenReadStream())
        {
            _storageService.UploadFile(directoryPath, stream);
        }
    }
    
    [HttpGet("downloadFile")]
    public FileStreamResult DownloadFile(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var stream = _storageService.DownloadFile(filePath);
        return new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName
        };
    }
    
    [HttpGet("deleteFile")]
    public void DeleteFile(string filePath)
    {
        _storageService.DeleteFile(filePath);
    }
    //-
    [HttpPost("createFolder")]
    public void CreateDirectory(string? directoryPath, string directoryName)
    {
        _storageService.CreateDirectory(directoryPath ,directoryName);
    }

    [HttpGet("downloadFolder")]
    public FileStreamResult DownloadDirectory(string directoryPath)
    {
        var fileName = Path.GetFileName(directoryPath);
        var stream = _storageService.DownloadDirectory(directoryPath);
        try
        {
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName + ".zip"
            };
            return res;
        }
        finally
        {
            _storageService.DeleteDirectory(directoryPath + ".zip");
        }

    }

    [HttpGet("deleteFolder")]
    public void DeleteDirectory(string directoryPath)
    {
        _storageService.DeleteDirectory(directoryPath);
    }

    [HttpGet("getAll")]
    public List<string> GetAllFilesAndDirectories(string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        var allFileAndDirectories = _storageService.GetAllFilesAndDirectories(directoryPath);
        return allFileAndDirectories;
    }
}
