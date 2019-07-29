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
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IService<Author> _service;

        public AuthorController(IService<Author> service)
        {
            _service = service;
            // _service = new BaseService<Author>(new BaseRepository<Author>());
        }

        
        // POST api/author
        [HttpPost]
        public IActionResult Post([FromBody] Author item)
        {
            try
            {
                _service.Post<AuthorValidator>(item);

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

        // POST api/author/{id}
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Author item, int id)
        {
            try
            {
                item.Id = id;
                _service.Put<AuthorValidator>(item);

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

        // DELETE api/author/{id}
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

        // GET api/author
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

        // GET api/author/{id}
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