using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Domain.Repository;
using BookShop.Service.Services;
using BookShop.Service.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IService<Book> _service;

        public BookController()
        {
            var bookRepository = new BookRepository();
            _service = new BaseService<Book>(bookRepository);
        }

        
        // POST api/book
        [HttpPost]
        public IActionResult Post([FromBody] Book item)
        {
            try
            {
                _service.Post<BookValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/book/{id}
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book item, int id)
        {
            try
            {
                item.Id = id;
                _service.Put<BookValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/book/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/book
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/book/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(_service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}