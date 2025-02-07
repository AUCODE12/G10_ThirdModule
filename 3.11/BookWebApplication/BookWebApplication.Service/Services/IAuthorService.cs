using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public interface IAuthorService
{
    Task<int> AddAuthorAsync(AuthorDto authorDto); //c
    Task<List<AuthorDto>> GetAllAuthorsAsync(); //r
    Task<AuthorDto> GetAuthorByIdAsync(int id); //rid
    Task UpdateAuthorAsync(AuthorDto authorDto); //u
    Task DeleteAuthorAsync(int id); //d
}