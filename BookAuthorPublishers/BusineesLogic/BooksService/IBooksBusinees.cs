using BookAuthorPublishers.Data.Models;
using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusinessLayer.BooksService
{
    public interface IBooksBusinees
    {
        void AddBookWithAuthors(BookDTO bookdto);
        BookwithAuthorsDTO GetBookById(int id);
        List<Book> GetAllBooks();
        Book UpdateBookById(int id, BookDTO book);
        void DeleteBookById(int id);
    }
}
