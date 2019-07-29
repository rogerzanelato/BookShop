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
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IService<Genre> _service;

        public GenreController(IService<Genre> service)
        {
            _service = service;
        }

        
        // POST api/genre
        [HttpPost]
        public IActionResult Post([FromBody] Genre item)
        {
            try
            {
                _service.Post<GenreValidator>(item);

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

        // POST api/genre/{id}
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Genre item, int id)
        {
            try
            {
                item.Id = id;
                _service.Put<GenreValidator>(item);

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

        // DELETE api/genre/{id}
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

        // GET api/genre
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

        // GET api/genre/{id}
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