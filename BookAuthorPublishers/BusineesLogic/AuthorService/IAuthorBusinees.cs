using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusineesLogic.AuthorService
{
    public interface IAuthorBusinees
    {
        void AddAuthor(AuthorDTO authordto);
        AuthWithBooksDTO GetAuthWithBooks(int id);
    }
}
