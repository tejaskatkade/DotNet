using LibraryApplication.Models;

namespace LibraryApplication.Repository
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBook(int id);
        List<Book> GetAllBooks();
        void DeleteBook(int id);
        void UpdateBook(Book book);
    }
}
