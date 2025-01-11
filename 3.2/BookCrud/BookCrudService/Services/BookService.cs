using BookCrud.DataAccess.Entity;
using BookCrud.Repository.Services;
using BookCrud.Service.DTOs;

namespace BookCrud.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService()
    {
        _bookRepository = new BookRepository();    
    }

    public Guid AddBook(BookDto bookDto)
    {
        var bookId = _bookRepository.AddBook(ConvertToBookEntity(bookDto));
        return bookId;
    }

    public void DeleteBook(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }

    public List<BookDto> GetAllBooks()
    {
        return _bookRepository.GetAllBooks()
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        return _bookRepository.GetAllBooks()
            .Where(b => b.Author.ToLower() == author.ToLower())
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        return _bookRepository.GetAllBooks()
            .Where(b => b.PublishedDate.Year > year)
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return _bookRepository.GetAllBooks()
            .OrderByDescending(b => b.Rating)
            .Select (b => ConvertToBookDto(b))
            .ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        return _bookRepository.GetAllBooks()
            .Where(b => b.Pages > minPages && b.Pages < maxPages)
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public BookDto GetByIdBook(Guid id)
    {
        return ConvertToBookDto(_bookRepository.GetByIdBook(id));
    }

    public BookDto GetMostPopularBook()
    {
        var mostPopularAmount = _bookRepository.GetAllBooks()
            .Max(b => b.NumberOfCopiesSold);
        var mostPopularBook = _bookRepository.GetAllBooks()
            .First(b => b.NumberOfCopiesSold == mostPopularAmount);
        return ConvertToBookDto(mostPopularBook);
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        return _bookRepository.GetAllBooks()
            .Where(b => b.PublishedDate.Year == years)
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public BookDto GetTopRatedBook()
    {
        var rating = _bookRepository.GetAllBooks()
            .Max(b => b.Rating);
        var topRatingBook = _bookRepository.GetAllBooks()
            .First(b => b.Rating == rating);
        return ConvertToBookDto(topRatingBook);
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        return _bookRepository.GetAllBooks()
            .Where(b => b.Author == author)
            .Count();
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        return _bookRepository.GetAllBooks()
            .Where (b => b.Title.Contains(keyword))
            .Select(b => ConvertToBookDto(b))
            .ToList();
    }

    public void UpdateBook(BookDto bookDto)
    {
        _bookRepository.UpdateBook(ConvertToBookEntity(bookDto));
    }

    private Book ConvertToBookEntity(BookDto bookDto)
    {
        return new Book()
        {
            Author = bookDto.Author,
            Id = bookDto.Id ?? Guid.NewGuid(),
            NumberOfCopiesSold = bookDto.NumberOfCopiesSold,
            Pages = bookDto.Pages,
            PublishedDate = bookDto.PublishedDate,
            Rating = bookDto.Rating,
            Title = bookDto.Title,
        };
    }

    private BookDto ConvertToBookDto(Book book)
    {
        return new BookDto()
        {
            Author = book.Author,
            Title = book.Title,
            Rating = book.Rating,
            PublishedDate = book.PublishedDate,
            Pages = book.Pages,
            Id = book.Id,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
        };
    }
}
