using BookAuthorPublishers.Data;
using BookAuthorPublishers.Data.Models;
using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusineesLogic.PublisherService
{
    public class PublisherBusiness : IPublisherBusiness
    {
        private readonly AppDbContext _context;
        public PublisherBusiness(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherDTO publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsDTO GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                 .Select(n => new PublisherWithBooksAndAuthorsDTO()
                 {
                     Name = n.Name,
                     BookAuthors = n.Books.Select(n => new BookAuthorDTO()
                     {
                         BookName = n.Title,
                         BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                     }).ToList()
                 }).FirstOrDefault();

            return _publisherData;
        }
    }
}
