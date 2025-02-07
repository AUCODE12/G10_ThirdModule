using BookWebApplication.DataAccess;
using BookWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Repository.Service;

public class AuthorRepository : IAuthorRepository
{
    private readonly MainContext _mainContext;
    public AuthorRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> AddAuthorAsync(Author author)
    {
        await _mainContext.Authors.AddAsync(author);
        await _mainContext.SaveChangesAsync();
        return author.Id;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var author = await GetAuthorByIdAsync(id);
        _mainContext.Authors.Remove(author);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await _mainContext.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var author = await _mainContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        if (author is null) throw new Exception("Not Found");
        return author;
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        _mainContext.Authors.Update(author);
        await _mainContext.SaveChangesAsync();
    }
}
