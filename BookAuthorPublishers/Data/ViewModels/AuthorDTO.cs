using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.Data.ViewModels
{
    public class AuthorDTO
    {
        public string FullName { get; set; }

    }

    public class AuthWithBooksDTO
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
