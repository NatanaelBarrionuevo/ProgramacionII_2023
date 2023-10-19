using FechaWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FechaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static readonly List<Moneda> lst = new List<Moneda>();

        /*
         public CashController()
        {
        lst = null
        }NO COMPILA PORQUE ES READ ONLY LA LISTA DE MONEDAS Y NO PUEDE CAMBIAR SU VALOR. SOLO GET, SO SET.
        UNA VEZ QUE ASUME UN VALOR NO PUEDE CMBIAR EN NINGUNA LINEA QUE LE SIGA.
        Tener en cuenta que al ser static nuestra lista vivira en memoria miesntas esté en ejecucuión nuestro programa
        y sera un atributo compartido por todos los objetos Moneda que se creen. Al ser static, debe ser inicializada
        cuando es declara porque es lo primero que el rin time levanta.

        */
        // GET: api/Cash == endopint
        [HttpGet]
        public IActionResult Get()
        {//Permite obtener los datos de todas las monedas cargadas.
            return Ok(lst);
        }
        // GET: api/Cash/NombreMoneda == endopint. NOTA:COMO PARTE DE LA URL VOY A ESTAR MANDANDO UN PARAMETRO
        [HttpGet("{Id}")]
        public IActionResult Get(string nombre)
        {//Permite obtener los datos de una moneda especifica.
            foreach (Moneda item in lst)
            {
                if (item.Nombre.Equals(nombre))
                {
                    return Ok(item);
                }
            }
            return NotFound("No se encontro la moneda!");
        }


        // POST api/Cash/Moneda
        [HttpPost("{oMoneda}")]
        public IActionResult Post(Moneda moneda)
        {//Permite añadir los datos de una moneda especifica.
            if (moneda != null && !string.IsNullOrEmpty(moneda.Nombre) && !string.IsNullOrWhiteSpace(moneda.Nombre))
            {
                lst.Add(moneda);
                return Ok("Se registro correctatemnete!");
            }
            return BadRequest();
        }
        // PUT api/Cash/Moneda
        [HttpPut]
        public IActionResult Put(Moneda oMoneda)
        {
            if (oMoneda != null)
            {//Si el objeto moneda no es nulo y si se encuentra en la lista, lo actualiza.
                foreach (Moneda x in lst)
                {
                    if (x.Nombre.Equals(oMoneda.Nombre))
                    {
                        x.Nombre = oMoneda.Nombre;
                        x.Valor = oMoneda.Valor;
                        return Ok("Se actualizo correctamente la moneda " + oMoneda.Nombre + " con valor de " + oMoneda.Valor);
                    }
                    return NotFound();
                }

            }
            return BadRequest();
        }

        //DELETE api/Cash/NombreMoneda
        [HttpDelete]
        public IActionResult Delete(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest();
            }
            foreach (Moneda x in lst)
            {
                if (x.Nombre.Equals(nombre))
                {
                    string n = x.Nombre;
                    double v = x.Valor;
                    lst.Remove(x);
                    return Ok("Se elimino correctamente la moneda " + n + " con valor de " + v);
                }
            }
            return NotFound();
        }
    }
}
