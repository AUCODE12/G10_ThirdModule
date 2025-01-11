using BookCrud.DataAccess.Entity;

namespace BookCrud.Repository.Services;

public interface IBookRepository
{
    Guid AddBook(Book book);

    List<Book> GetAllBooks();

    Book GetByIdBook(Guid id);

    void DeleteBook(Guid id);

    void UpdateBook(Book book);

}