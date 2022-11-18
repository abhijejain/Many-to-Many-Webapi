using BookAuthorPublishers.BusineesLogic.AuthorService;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorBusinees _business;
        public AuthorController(IAuthorBusinees business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO author)
        {
            _business.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _business.GetAuthWithBooks(id);
            return Ok(response);
        }


    }
}
