using BookWebApplication.Service.DTOs;
using BookWebApplication.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApplication.Server.Controllers;

[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("add")]
    public async Task<int> AddBookAsync(BookDto bookDto)
    {
        return await _bookService.AddBookAsync(bookDto);
    }

    [HttpGet("getAll")]
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        return await _bookService.GetAllBooksAsync();
    }

    [HttpGet("getById/{id}")]
    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        return await _bookService.GetBookByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task UpdateBookAsync(BookDto bookDto)
    {
        await _bookService.UpdateBookAsync(bookDto);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteBookAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
    }
}
