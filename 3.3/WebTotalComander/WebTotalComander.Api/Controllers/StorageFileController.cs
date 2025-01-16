using Microsoft.AspNetCore.Mvc;
using WebTotalComander.Services.DTOs;
using WebTotalComander.Services.Services;
using WTelegram;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TL;
//using WTelegram.Helpers;
namespace WebTotalComander.Api.Controllers;

[Route("api/storageFile")]
[ApiController]
public class StorageFileController : ControllerBase
{
    private readonly IFileService _fileService;

    public StorageFileController()
    {
        _fileService = new FileService();
    }

    [HttpPost("uploadFile")]
    public Guid UploadFile(StorageFileDto storageFileDto)
    {
        return _fileService.AddFile(storageFileDto);
    }

    [HttpGet("getAllFiles")]
    public List<StorageFileDto> GetAllFiles()
    {
        return _fileService.GetAllFiles();
    }

    [HttpGet("getFileById")]
    public StorageFileDto GetFileById(Guid id)
    {
        return _fileService.GetFileById(id);
    }

    [HttpPut("putFile")]
    public void PutFile(StorageFileDto storageFileDto)
    {
        _fileService.UpgradeFile(storageFileDto);
    }

    [HttpDelete("deleteFile")]
    public void DeleteFile(Guid id)
    {
        _fileService.DeleteFile(id);
    }

    //
    [HttpPost("getAllFilesByDirectoryLocation")]
    public void GetAllFilesByDirectoryLocation(string location)
    {
        _fileService.GetAllFilesByDirectoryLocation(location);
    }

    ///
    [HttpPost("auth.sendCode")]
    public async Task<IActionResult> SendAuthCodeTg(string phoneNumber)
    {
        try
        {
            // Telegram mijozini ishga tushirish
            using var client = new WTelegram.Client(Config);
            //var sentCode = await client.Auth_SendCode(phoneNumber, WTelegram.Helpers.);

            //var sentCode = await client.Auth_SendCode(phoneNumber, CodeType.SMS);

            CodeSettings codeSettings = new() { allow_flashcall = false, allow_sms = true };
            var sentCode = await client.Auth_SendCode(phoneNumber, api_id, api_hash, codeSettings);

            //var sentCode = await client.Auth_SendCode(phoneNumber, codeSettings);

            return Ok("Code sent successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to send code: {ex.Message}");
        }
    }

    // Konfiguratsiya funksiyasi
    private static string Config(string what) => what switch
    {
        "api_id" => "22338291",
        "api_hash" => "79290dc6b00502077b6a8194f699b760",
        _ => null
    };

}
