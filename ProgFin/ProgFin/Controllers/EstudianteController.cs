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
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _estudianteService.GetAll()
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Estudiante model)
        {
            return Ok(
                _estudianteService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Estudiante model)
        {
            return Ok(
                _estudianteService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _estudianteService.Delete(id)
            );
        }
    }
}