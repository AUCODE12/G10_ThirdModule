using BookWebApplication.DataAccess.Entities;
using BookWebApplication.Repository.Service;
using BookWebApplication.Service.DTOs;

namespace BookWebApplication.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> AddBookAsync(BookDto bookDto)
    {
        return await _bookRepository.AddBookAsync(ConvertToBookEntity(bookDto));
    }

    public async Task DeleteBookAsync(int id)
    {
        await _bookRepository.DeleteBookAsync(id);
    }

    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return books.Select(b => ConvertToBookDto(b)).ToList();
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        return ConvertToBookDto(await _bookRepository.GetBookByIdAsync(id));
    }

    public async Task UpdateBookAsync(BookDto bookDto)
    {
        await _bookRepository.UpdateBookAsync(ConvertToBookEntity(bookDto));
    }

    private Book ConvertToBookEntity(BookDto bookDto)
    {
        return new Book
        {
            Id = bookDto.Id ?? 0,
            Title = bookDto.Title,
            AuthorId = bookDto.AuthorId,
            Genre = bookDto.Genre,
            //Author = bookDto.Author,
            //Comments = bookDto.Comments
        };
    }

    private BookDto ConvertToBookDto(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Genre = book.Genre,
            Author = book.Author,
            Comments = book.Comments
        };
    }
}
