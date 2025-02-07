using BookWebApplication.Service.DTOs;
using BookWebApplication.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApplication.Server.Controllers;

[Route("api/author")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("add")]
    public async Task<int> AddAuthorAsync(AuthorDto authorDto)
    {
        return await _authorService.AddAuthorAsync(authorDto);
    }

    [HttpGet("getAll")]
    public async Task<List<AuthorDto>> GetAllAuthorsAsync()
    {
        return await _authorService.GetAllAuthorsAsync();
    }

    [HttpGet("getById/{id}")]
    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        return await _authorService.GetAuthorByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task UpdateAuthorAsync(AuthorDto authorDto)
    {
        await _authorService.UpdateAuthorAsync(authorDto);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteAuthorAsync(int id)
    {
        await _authorService.DeleteAuthorAsync(id);
    }
}
