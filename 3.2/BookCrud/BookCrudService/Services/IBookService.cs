using BookCrud.Service.DTOs;

namespace BookCrud.Service.Services;

public interface IBookService
{
    Guid AddBook(BookDto bookDto);

    List<BookDto> GetAllBooks();

    BookDto GetByIdBook(Guid id);

    void DeleteBook(Guid id);

    void UpdateBook(BookDto bookDto);

    List<BookDto> GetAllBooksByAuthor(string author); 

    BookDto GetTopRatedBook(); 

    List<BookDto> GetBooksPublishedAfterYear(int year); 

    BookDto GetMostPopularBook();

    List<BookDto> SearchBooksByTitle(string keyword); 

    List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);

    int GetTotalCopiesSoldByAuthor(string author); 

    List<BookDto> GetBooksSortedByRating(); 

    List<BookDto> GetRecentBooks(int years); 
}