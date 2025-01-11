using BookCrud.Service.DTOs;

namespace BookCrud.Service.Extensions;

public static class BookExtensions
{
    public static int Pages(this BookDto book)
    {
        return book.Pages;
    }
    public static int TotalNumberOfCopiesSold(this List<BookDto> books)
    {
        return books.Sum(b => b.NumberOfCopiesSold);
    }
}
