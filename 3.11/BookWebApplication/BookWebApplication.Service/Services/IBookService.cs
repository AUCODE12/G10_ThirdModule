using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public interface IBookService
{
    Task<int> AddBookAsync(BookDto bookDto); //c
    Task<List<BookDto>> GetAllBooksAsync(); //r
    Task<BookDto> GetBookByIdAsync(int id); //rid
    Task UpdateBookAsync(BookDto bookDto); //u
    Task DeleteBookAsync(int id); //d
}