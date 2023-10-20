using Microsoft.AspNetCore.Mvc;
using ProductosWebApl.Datos.DTOs;
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
        private IServicio servicio;


        public ProductoController()
        {
            this.servicio = new Servicio();
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(servicio.GetProductos());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductoDTO x = new ProductoDTO();
            x = servicio.GetProductos(id);
            if (x != null)
            {
                return Ok(x);
            }

            return NotFound("No hay ningun producto asociado al identificador ingresado");
        }

        // POST api/<ProductoController>
        [HttpPost("{oProducto}")]
        public IActionResult Post(ProductoDTO oProducto)
        {
            switch (ValidarDatos(oProducto))
            {

                case 1:
                    return BadRequest("El nombre del producto no puede ser una cadena vacia");
                    break;
                case 2:
                    return BadRequest("El nombre del producto solo puede contener letras");
                case 3:
                    return BadRequest("El precio del producto debe ser mayor a 0");
                    break;
            }
            int x = servicio.AgregarProducto(oProducto);
            if (x > 0)
            {
                return Ok("Se ah cargado exitosamente el producto: \nNombre: " + oProducto.Nombre + "\nPrecio: " + oProducto.Precio + "\nCodigo: " + (x - 1));
            }
            return BadRequest();
        }

        private int ValidarDatos(ProductoDTO oProducto)
        {
            int x = 0;

            if (string.IsNullOrEmpty(oProducto.Nombre) || string.IsNullOrWhiteSpace(oProducto.Nombre))
            {
                x = 1;
            }
            foreach (Char c in oProducto.Nombre)
            {
                if (c <= 31 && c >= 33 || c < 65 && c > 90 || c < 97 && c > 122)
                {
                    x = 2;
                }
            }
            if (oProducto.Precio <= 0)
            {
                x = 3;
            }
            return x;
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
            if (oProducto.Precio <= 0)
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
                    return BadRequest("El precio del producto debe ser mayor a 0");
                    break;

            }
            if (servicio.ActualizarProducto(oProducto) == 1)
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
            int x = servicio.EliminarProducto(id);
            if (x == 1)
            {
                return Ok("El producto nro  " + id + " fue eliminado correctamente.");
            }
            if (x == 0)
            {
                return BadRequest("El producto ya fue borrado");
            }
                return NotFound("No se encontro ningun prodcuto asociado con el idnetificador ingresado");
        }
    }
}
