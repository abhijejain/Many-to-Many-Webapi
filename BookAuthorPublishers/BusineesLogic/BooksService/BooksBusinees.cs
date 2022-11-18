using BookAuthorPublishers.Data;
using BookAuthorPublishers.Data.Models;
using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusinessLayer.BooksService
{
    public class BooksBusinees : IBooksBusinees
    {
        private readonly AppDbContext _context;
        public BooksBusinees(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookDTO bookdto)
        {
            var _book = new Book()
            {
                Title = bookdto.Title,
                Description = bookdto.Description,
                IsRead = bookdto.IsRead,
                DateRead = bookdto.IsRead ? (DateTime?)bookdto.DateRead.Value : null,
                Rate = bookdto.IsRead ? (int?)bookdto.Rate.Value : null,
                Genre = bookdto.Genre,
                CoverUrl = bookdto.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = bookdto.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in bookdto.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();

            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public BookwithAuthorsDTO GetBookById(int id)
        {
            var bookswithAuthors = _context.Books.Select(bookdto => new BookwithAuthorsDTO()
            {
                Title = bookdto.Title,
                Description = bookdto.Description,
                IsRead = bookdto.IsRead,
                DateRead = bookdto.IsRead ? (DateTime?)bookdto.DateRead.Value : null,
                Rate = bookdto.IsRead ? (int?)bookdto.Rate.Value : null,
                Genre = bookdto.Genre,
                CoverUrl = bookdto.CoverUrl,
                PublisherName = bookdto.Publisher.Name,
                AuthorName = bookdto.Book_Authors.Select(x => x.Author.FullName).ToList()
            }).FirstOrDefault();
            return bookswithAuthors;
        }

        public Book UpdateBookById(int bookId, BookDTO book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? (DateTime?)book.DateRead.Value : null;
                _book.Rate = book.IsRead ? (int?)book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }

    }
}
