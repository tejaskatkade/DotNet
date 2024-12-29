using LibraryApplication.Models;
using LibraryApplication.Service;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService) {
            this.bookService = bookService;
        }
        public IActionResult Index()
        {
            List<Book> books =  bookService.GetAllBooks();
            this.ViewData["books"] = books;
            return View();
        }

            
        //GET
        public IActionResult GetBook(int id)
        {
            Book books = bookService.GetBook(id);
            this.ViewData["books"] = books;
            return View();
        }

        //Delete

        [HttpPost]        
        public IActionResult DeleteBook(int id)
        {
            bookService.RemoveBook(id);
            return RedirectToAction("Index");
        }

        // ADD

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
            }
            return RedirectToAction("Index");
        }



        // UPDATE
        
        public IActionResult UpdateBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.UpdateBook(book);
            }
            return RedirectToAction("Index");
        }



    }
}
