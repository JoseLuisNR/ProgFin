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
    public class TipolibroController : Controller
    {
        private readonly ITipolibroService _TipolibroService;
        public TipolibroController(ITipolibroService TipolibroService)
        {
            _TipolibroService = TipolibroService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _TipolibroService.GetAll()
            );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Tipolibro model)
        {
            return Ok(
                _TipolibroService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Tipolibro model)
        {
            return Ok(
                _TipolibroService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _TipolibroService.Delete(id)
            );
        }
    }
}