using BookWebApplication.DataAccess;
using BookWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Repository.Service;

public class BookRepository : IBookRepository
{
    private readonly MainContext _mainContext;

    public BookRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> AddBookAsync(Book book)
    {
        await _mainContext.Books.AddAsync(book);
        await _mainContext.SaveChangesAsync();
        return book.Id;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await GetBookByIdAsync(id);
        _mainContext.Books.Remove(book);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _mainContext.Books.ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book = await _mainContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book is null) throw new Exception("Not Found");
        return book;
    }

    public async Task UpdateBookAsync(Book book)
    {
        _mainContext.Books.Update(book);
        await _mainContext.SaveChangesAsync();
    }
}
