using BookAuthorPublishers.BusineesLogic.PublisherService;
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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherBusiness _business;
        public PublisherController(IPublisherBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherDTO publisher)
        {
            _business.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _business.GetPublisherData(id);

            return Ok(_response);
        }
    }
}
