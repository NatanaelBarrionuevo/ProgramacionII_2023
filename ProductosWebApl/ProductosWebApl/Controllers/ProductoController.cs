using Microsoft.AspNetCore.Mvc;
using ProductosWebApl.Datos.Implementaciones;
using ProductosWebApl.Datos.Interfaz;
using ProductosWebApl.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductosWebApl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoDao servicio;


        public ProductoController()
        {
            this.servicio = new ProductoDao();
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(servicio.ConsultarProductos());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(servicio.ConsultarProductos(id));
        }

        // POST api/<ProductoController>
        [HttpPost("{oProducto}")]
        public IActionResult Post(Producto oProducto)
        {
            switch (ValidarDatos(oProducto))
            {
                case 1:
                    return BadRequest("El codigo del producto debe ser mayor a 0");
                    break;
                case 2:
                    return BadRequest("El nombre del producto no puede ser una cadena vacia");
                    break;
                case 3:
                    return BadRequest("El nombre del producto solo puede contener letras");
                case 4:
                    return BadRequest("El precio del producto no puede ser menor a 0");
                    break;
            }
            if (servicio.CargarProductos(oProducto) == 1)
            {
                return Ok("Se ah cargado exitosamente el producto: \nNombre: " + oProducto.Nombre + "\nPrecio: " + oProducto.Precio + "\nCodigo: " + oProducto.Codigo);
            }
            return BadRequest();
        }

        private int ValidarDatos(Producto oProducto)
        {
            int x = 0;
            if (oProducto.Codigo <= 0)
            {
                x = 1;
            }
            if (string.IsNullOrEmpty(oProducto.Nombre) || string.IsNullOrWhiteSpace(oProducto.Nombre))
            {
                x = 2;
            }
            foreach (Char c in oProducto.Nombre)
            {
                if (c <= 31 && c >= 33 || c < 65 && c > 90 || c < 97 && c > 122)
                {
                    x = 3;
                }
            }
            if (oProducto.Precio < 0)
            {
                x = 4;
            }
            return x;
        }
        // PUT api/<ProductoController>/5
        [HttpPut("{oProducto}")]
        public IActionResult Put(Producto oProducto)
        {
            switch (ValidarDatos(oProducto))
            {
                case 1:
                    return BadRequest("El codigo del producto debe ser mayor a 0");
                    break;
                case 2:
                    return BadRequest("El nombre del producto no puede ser una cadena vacia");
                    break;
                case 3:
                    return BadRequest("El nombre del producto solo puede contener letras");
                case 4:
                    return BadRequest("El precio del producto no puede ser menor a 0");
                    break;

            }
            if (servicio.CargarProductos(oProducto) == 1)
            {
                return Ok("Se ah cargado exitosamente el producto: \nNombre: " + oProducto.Nombre + "\nPrecio: " + oProducto.Precio + "\nCodigo: " + oProducto.Codigo);
            }
            else
            {
                return NotFound("No se encontro ningun prodcuto asociado con el idnetificador ingresado");
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (servicio.BajaProductos(id).Equals(1))
            {
                return Ok("El producto nro  " + id + " fue eliminado correctamente.");
            }
            return NotFound("No se encontro ningun prodcuto asociado con el idnetificador ingresado");
        }
    }
}
