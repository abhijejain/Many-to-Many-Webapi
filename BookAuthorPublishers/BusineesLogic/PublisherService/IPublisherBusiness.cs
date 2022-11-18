using BookAuthorPublishers.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorPublishers.BusineesLogic.PublisherService
{
    public interface IPublisherBusiness
    {
        void AddPublisher(PublisherDTO publisher);
        PublisherWithBooksAndAuthorsDTO GetPublisherData(int publisherId);
    }
}
