using BookWebApplication.Service.DTOs;
using BookWebApplication.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApplication.Server.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<int> AddUserAsync(UserDto userDto)
    {
        return await _userService.AddUserAsync(userDto);
    }
    
    [HttpGet("getAll")]
    public async Task<List<UserGetDto>> GetAllUsersAsync()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet("getById/{id}")]
    public async Task<UserGetDto> GetUserByIdAsync(int id)
    {
        return await _userService.GetUserByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task UpdateUserAsync(UserDto updatedUserDto)
    {
        await _userService.UpdateUserAsync(updatedUserDto);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteUserAsync(int id)
    {
        await _userService.DeleteUserAsync(id);
    }
}
