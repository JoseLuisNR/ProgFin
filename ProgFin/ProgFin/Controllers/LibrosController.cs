using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ProgFin.Controllers
{
    [Route("[controller]")]
    public class LibrosController : Controller
    {
        private readonly ILibrosService _LibrosService;
        public LibrosController(ILibrosService LibrosService)
        {
            _LibrosService = LibrosService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _LibrosService.GetAll()
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Libros model)
        {
            return Ok(
                _LibrosService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Libros model)
        {
            return Ok(
                _LibrosService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _LibrosService.Delete(id)
            );
        }
    }
}