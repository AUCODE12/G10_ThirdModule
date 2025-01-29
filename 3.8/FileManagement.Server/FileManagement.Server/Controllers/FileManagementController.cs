using FileManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManagement.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class FileManagementController : ControllerBase
{
    private readonly IFileManagementService _fileManagementService;

    public FileManagementController(IFileManagementService fileManagementService)
    {
        _fileManagementService = fileManagementService;
    }

    [HttpPost("uploadFile")]
    public async Task UploadFile(string? directoryPath, IFormFile file)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.FileName);

        using (var stream = file.OpenReadStream())
        {
            await _fileManagementService.UploadFileAsync(directoryPath, stream);
        }
        }

    [HttpPost("uploadFiles")]
    public async Task UploadFiles(List<IFormFile> files, string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        var mainPath = directoryPath;
        if (files == null || files.Count == 0)
        {
            throw new Exception("files is empty or null");
        }

        foreach (var file in files)
        {
            directoryPath = Path.Combine(mainPath, file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await _fileManagementService.UploadFileAsync(directoryPath, stream);
            }
        }
    }

    [HttpDelete("deleteFile")]
    public async Task DeleteFileAsync(string filePath)
    {
        await _fileManagementService.DeleteFileAsync(filePath);
    }

    [HttpGet("downloadFile")]
    public async Task<FileStreamResult> DownloadFileAsync(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var stream = await _fileManagementService.DownloadFileAsync(filePath);
        return new FileStreamResult(stream, "aplication/octet-stream")
        {
            FileDownloadName = fileName,
        };
    }

    [HttpPost("createFolder")]
    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await _fileManagementService.CreateDirectoryAsync(directoryPath);
    }

    [HttpDelete("deleteFolder")]
    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await _fileManagementService.DeleteDirectoryAsync(directoryPath);
    }

    [HttpGet("downloadFolder")]
    public async Task<FileStreamResult> DownloadDirectoryAsync(string directoryPath)
    {
        var directoryName = Path.GetFileName(directoryPath);
        var stream = await _fileManagementService.DownloadDirectoryAsync(directoryPath);
        return new FileStreamResult(stream, "aplication/octet-stream")
        {
            FileDownloadName = directoryName,
        };
    }

    [HttpGet("getAll")]
    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string? directoryPath)
    {
        return await _fileManagementService.GetAllFilesAndDirectoriesAsync(directoryPath);
    }
}
