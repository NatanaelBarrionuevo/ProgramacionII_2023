using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdenesBack.Acceso_a_datos.DTOs;
using OrdenesBack.Dominio;
using OrdenesBack.Negocio.Implementacion;
using OrdenesBack.Negocio.Interfaz;

namespace OrdenesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private IAplicacion servicio;

        public OrdenesController()
        {
            servicio = new Aplicacion();
        }


        [HttpGet("Materiales")]

        public IActionResult GetMateriales()
        {
            List<Material> lst = new List<Material>();
            lst = servicio.ConsultarMateriales();
            if (lst != null)
            {
                return Ok(lst);
            }
            return BadRequest(lst);
        }

        [HttpPost("{oOrden}")]
        public IActionResult PostOrden(OrdenRetiroDTO oOrden)
        {
            switch (ValidarDatos(oOrden))
            {
                case 1:
                    return BadRequest("El objeto Receta como su lista de detalles no pueden ser nulas.");
                case 2:
                    return BadRequest("El Responsable de la Orden no puede ser una cadena de texto vacia.");
                case 3:
                    return BadRequest("El formato de Responsable de la orden solo acepta letras.");
                case 4:
                    return BadRequest("Tanto el stock y cantidades de material deben ser mayores a 0.");
                case 5:
                    return BadRequest("El Nombre del Material no puede ser una cadena vacia.");
                case 6:
                    return BadRequest("El formato del Nombre de los Matariales del detalle de la orden solo acepta letras.");
            }

            if (servicio.CrearOrden(oOrden))
            {
                return Ok("La orden fue ingresado correctamente, que tenga un buen dia!");
            }
            return BadRequest();
        }

        private int ValidarDatos(OrdenRetiroDTO oOrden)
        {
            int n = 0;
            if (oOrden == null || oOrden.Detalle == null)
            {
                n = 1;
            }
            if (string.IsNullOrEmpty(oOrden.Responsable) || string.IsNullOrWhiteSpace(oOrden.Responsable))
            {
                n = 2;
            }
            foreach (Char c in oOrden.Responsable)
            {
                if (c < 31 && c > 33 || c < 65 && c > 90 || c < 97 && c > 122)
                {
                    n = 3;
                }
            }
            foreach (DetalleOrdenDTO x in oOrden.Detalle)
            {

                if (x.Material.Codigo <= 0 || x.Material.Stock <= 0)
                {
                    n = 4;
                }
                if (string.IsNullOrEmpty(x.Material.Nombre) || string.IsNullOrWhiteSpace(x.Material.Nombre))
                {
                    n = 5;
                }
                foreach (Char c in x.Material.Nombre)
                {
                    if (c < 31 && c > 33 || c < 65 && c > 90 || c < 97 && c > 122)
                    {
                        n = 6;
                    }
                }
            }
            return n;
        }
    }
}
