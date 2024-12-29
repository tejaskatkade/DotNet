using LibraryApplication.Models;
using LibraryApplication.Repository;
using LibraryApplication.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService bookService;
        public BookController(IBookService bookService) {
            this.bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public List<Book> Get()
        {
            return bookService.GetAllBooks();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bookService.GetBook(id);

            //return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            bookService.AddBook(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Book book)
        {
            bookService.UpdateBook(book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.RemoveBook(id);
        }
    }
}
