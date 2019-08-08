using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ProgFin.Controllers
{
    [Route("PrestamosController")]
    public class PrestamosController : Controller
    {
        private readonly IPrestamosService _PrestamosService;
        public PrestamosController(IPrestamosService PrestamosService)
        {
            _PrestamosService = PrestamosService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _PrestamosService.GetAll()
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Prestamos model)
        {
            return Ok(
                _PrestamosService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Prestamos model)
        {
            return Ok(
                _PrestamosService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _PrestamosService.Delete(id)
            );
        }
    }
}