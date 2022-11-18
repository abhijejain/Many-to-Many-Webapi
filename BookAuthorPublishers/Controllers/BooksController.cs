using BookAuthorPublishers.BusinessLayer.BooksService;
using BookAuthorPublishers.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBusinees _business;
        public BooksController(IBooksBusinees business)
        {
            _business = business;
        }
       
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO book)
        {
            _business.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _business.GetBookById(id);
            return Ok(book);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _business.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookDTO book)
        {
            var updatedBook = _business.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _business.DeleteBookById(id);
            return Ok();
        }
    }
}
