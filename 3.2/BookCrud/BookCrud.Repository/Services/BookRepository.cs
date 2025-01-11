using BookCrud.DataAccess.Entity;
using System.Text.Json;

namespace BookCrud.Repository.Services;

public class BookRepository : IBookRepository
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly List<Book> _books;

    public BookRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Books.json");
        //_directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        //if (!Directory.Exists(_directoryPath))
        //{
        //    Directory.CreateDirectory(_directoryPath);
        //}

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }

        _books = GetAllBooks();
    }
    public Guid AddBook(Book book)
    {
        _books.Add(book);
        SaveData();
        return book.Id;
    }

    public void DeleteBook(Guid id)
    {
        var book = GetByIdBook(id);
        _books.Remove(book);
        SaveData();
    }

    public List<Book> GetAllBooks()
    {
        var bookJson = File.ReadAllText(_filePath);
        var books = JsonSerializer.Deserialize<List<Book>>(bookJson);
        return books;
    }

    public Book GetByIdBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book is null)
        {
            throw new NullReferenceException("Null obj");
        }
        return book;

    }

    public void UpdateBook(Book book)
    {
        var fromDbBook = GetByIdBook(book.Id);
        var index = _books.IndexOf(fromDbBook);
        _books[index] = book;
        SaveData();
    }

    private void SaveData()
    {
        var bookJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_filePath, bookJson);
    }
}
