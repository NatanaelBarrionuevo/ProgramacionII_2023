using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using RecetaWebApi.Datos.Implementaciones;
using RecetaWebApi.Datos.Interfaz;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecetaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private IAplicacion servicio;

        public RecetaController()
        {
            servicio = new Aplicacion();
        }
        // GET: api/<RecetaController>
        [HttpGet]
        public IActionResult Get()
        {

            return Ok();
        }

        // GET api/<RecetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecetaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecetaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecetaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
