using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Repository.Service;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<int> AddAuthorAsync(AuthorDto authorDto)
    {
        return await _authorRepository.AddAuthorAsync(ConvertToAuthorEntity(authorDto));
    }

    public async Task DeleteAuthorAsync(int id)
    {
        await _authorRepository.DeleteAuthorAsync(id);
    }

    public async Task<List<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAuthorsAsync();
        return authors.Select(a => ConvertToDto(a)).ToList();
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        return ConvertToDto(await _authorRepository.GetAuthorByIdAsync(id));
    }

    public async Task UpdateAuthorAsync(AuthorDto authorDto)
    {
        await _authorRepository.UpdateAuthorAsync(ConvertToAuthorEntity((AuthorDto)authorDto));
    }

    private Author ConvertToAuthorEntity(AuthorDto authorDto)
    {
        return new Author
        {
            Bio = authorDto.Bio,
            Id = authorDto.Id ?? 0,
            Name = authorDto.Name,
        };
    }

    private AuthorDto ConvertToDto(Author author)
    {
        return new AuthorDto
        {
            Name = author.Name,
            Id = author.Id,
            Bio = author.Bio,
        };
    }
}
