using LibraryApplication.Models;
using LibraryApplication.Repository;

namespace LibraryApplication.Service
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository) { 
            this.bookRepository =  bookRepository;
        }
        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return bookRepository.GetBook(id);
        }

        public void RemoveBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public void UpdateBook(Book book)
        {
            bookRepository.UpdateBook(book);   
        }
    }
}
