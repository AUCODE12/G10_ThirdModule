using BookWebApplication.DataAccess.Entities;

namespace BookWebApplication.Repository.Service;

public interface IAuthorRepository
{
    Task<int> AddAuthorAsync(Author author); //c
    Task<List<Author>> GetAllAuthorsAsync(); //r
    Task<Author> GetAuthorByIdAsync(int id); //rid
    Task UpdateAuthorAsync(Author author); //u
    Task DeleteAuthorAsync(int id); //d
}