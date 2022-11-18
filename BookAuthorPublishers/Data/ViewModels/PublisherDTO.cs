using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.Data.ViewModels
{
    public class PublisherDTO
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsDTO
    {
        public string Name { get; set; }

        public List<BookAuthorDTO> BookAuthors { get; set; }
    }

    public class BookAuthorDTO
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
