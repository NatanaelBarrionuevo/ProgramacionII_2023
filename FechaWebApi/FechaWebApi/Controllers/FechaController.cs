using FechaWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FechaWebApi.Controllers
{
    [Route("api/[controller]")]//Politica de RUTEO se accede al endpoint raiz de la WebApi añadiendo /api/Fecha, osea, el nombre del Controller
    [ApiController]//Indica que es un Web Api
    public class FechaController : ControllerBase//Herede de Controller o ControllerBase
    {
        [HttpGet]//Indica que se accede al endpoint mediante el verbo HTTP GET
        public IActionResult Get()
        {
            return Ok(new Fecha());//Retorna un codigo 200 y un oFecha.
        }
    }
}
