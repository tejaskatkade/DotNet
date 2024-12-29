using LibraryApplication.Models;

namespace LibraryApplication.Service
{
    public interface IBookService
    {
        void AddBook(Book book);
        Book GetBook(int id);
        List<Book> GetAllBooks();
        void UpdateBook(Book book);
        void RemoveBook(int id);
    }
}
