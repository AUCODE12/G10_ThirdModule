using Microsoft.AspNetCore.Mvc;
using WebFileManagment.Service.Services;

namespace WebFileManagement.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class WebFileManagemantController : ControllerBase
{
    private readonly IWebFileService _webFileService;

    public WebFileManagemantController(IWebFileService webFileService)
    {
        _webFileService = webFileService;
    }

    [HttpPost("uploadFile")]
    public async Task UploadFile(string? directoryPath, IFormFile file)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.FileName);
        using (var stream = file.OpenReadStream())
        {
            await _webFileService.UploadFileAsync(directoryPath, stream);
        }
    }

    [HttpDelete("deleteFile")]
    public async Task DeleteFile(string filePath)
    {
        await _webFileService.DeleteFileAsync(filePath);
    }

    [HttpDelete("deleteFolder")]
    public async Task DeleteFolder(string directoryaPath)
    {
        await _webFileService.DeleteDirectoryAsync(directoryaPath);
    }

    [HttpGet("")]
    public 
}
