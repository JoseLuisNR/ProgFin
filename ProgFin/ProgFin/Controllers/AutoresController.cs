using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ProgFin.Controllers
{
    [Route("AutoresController")]
    public class AutoresController : Controller
    {
        private readonly IAutoresService _AutoresService;
        public AutoresController(IAutoresService AutoresService)
        {
            _AutoresService = AutoresService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _AutoresService.GetAll()
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Autores model)
        {
            return Ok(
                _AutoresService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Autores model)
        {
            return Ok(
                _AutoresService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _AutoresService.Delete(id)
            );
        }
    }
}