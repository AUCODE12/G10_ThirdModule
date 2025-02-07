using BookWebApplication.DataAccess.Entities;

namespace BookWebApplication.Repository.Service;

public interface IBookRepository
{
    Task<int> AddBookAsync(Book book); //c
    Task<List<Book>> GetAllBooksAsync(); //r
    Task<Book> GetBookByIdAsync(int id); //rid
    Task UpdateBookAsync(Book book); //u
    Task DeleteBookAsync(int id); //d
}