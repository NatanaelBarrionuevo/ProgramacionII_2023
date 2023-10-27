using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestoBack.Datos.DTOs;
using PresupuestoBack.Servicio;
using PresupuestosBack.Dominio;

namespace PresupuestosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private IServicio servicio;

        public PresupuestoController()
        {
            servicio = new Servicio();
        }

        [HttpGet("/productos")]
        public IActionResult GetProductos() 
        { 
            List<Producto>lst = servicio.ObtenerProductos();
            if(lst.Count == 0)
            {
                return NoContent();
            }
            return Ok(lst);
        }

        [HttpPost("/presupuesto")]
        public IActionResult PostPresupuesto(PresupuestoDTO oPresupuesto)
        {
            if (oPresupuesto.Equals(null))
            {
                return BadRequest("No admite objetos Presupuesto nulos!.");
            }
            return servicio.AgregarPresupuesto(oPresupuesto) ? Ok("El Presupuesto ah sido cargado exitosamente") : StatusCode(500, "Error interno intente nuevamnete mas tarde");
        }

        [HttpPut("/presupuesto")]
        public IActionResult PutPresupuesto(PresupuestoDTO dto)
        {
            if(dto == null)
            {
                return BadRequest("No admite objetos Presupuesto nulos!.");
            }
            return servicio.ModificarPresupuesto(dto)? Ok("El Presupuesto ah sido modificado exitosamente") : StatusCode(500, "Error interno intente nuevamnete mas tarde");
        }

        [HttpDelete("/presupuesto")]
        public IActionResult DeletePresupuesto(int id)
        {
            if (id > 0l)
            {
                return BadRequest("No admite objetos Presupuesto nulos!.");
            }
            return servicio.EliminarPresupuesto(id) ? Ok("El Presupuesto ah sido eliminado exitosamente") : StatusCode(500, "Error interno intente nuevamnete mas tarde");
        }
    }
   
    
}
