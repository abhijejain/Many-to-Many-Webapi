using BookAuthorPublishers.Data;
using BookAuthorPublishers.Data.Models;
using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusineesLogic.AuthorService
{
    public class AuthorBusinees :IAuthorBusinees
    {
        private readonly AppDbContext _context;
        public AuthorBusinees(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDTO authordto)
        {
            var _author = new Author()
            {
                FullName = authordto.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthWithBooksDTO GetAuthWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthWithBooksDTO()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
