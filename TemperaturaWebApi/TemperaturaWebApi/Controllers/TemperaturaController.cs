using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TemperaturaWebApi.Datos;
using TemperaturaWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemperaturaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {


        // GET: api/<TemperaturaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TempSingletton.getInstance().GetList());
        }

        // GET api/<TemperaturaController>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int cod)
        {
            if (cod <= 0)
            {
                return BadRequest("EL identificador de la medicion de teperatura debe ser mayor a cero.");
            }
            List<Temperatura> lst = new List<Temperatura>();
            if (lst != null) { return Ok(lst); }
            return NotFound("El codigo ingresado no tiene asociado ningun idspositivo IOT");
        }

        // POST api/<TemperaturaController>
        [HttpPost("{oTemperatura}")]
        public IActionResult Post(Temperatura oTemperatura)
        {
            switch (ValidarDatos(oTemperatura))
            {
                case 1:
                    return BadRequest("El objeto es nulo");
                    break;
                case 2:
                    return BadRequest("El identificador de la temperatura debe ser mayor a cero");
                    break;
                case 3:
                    return BadRequest("La temperatura debe oscilar entre -70° y 70°");
                    break;
                case 4:
                    return BadRequest("La temperatura debe oscilar entre -70° y 70°");
                    break;
            }
            return Ok(TempSingletton.getInstance().InsertTemp(oTemperatura));
        }
        private int ValidarDatos(Temperatura oTemperatura)
        {
            int n = 0;
            if (oTemperatura == null) { n = 1; }
            if (oTemperatura.CodIOT <= 0) { n = 2; }
            if (oTemperatura.Valor < -70 && oTemperatura.Valor > 70) { n = 3; }
            if (!DateTime.TryParse(oTemperatura.FechaHora.ToString(), out _) || string.IsNullOrEmpty(oTemperatura.FechaHora.ToString())) { n = 4; }
            return n;
        }

        // PUT api/<TemperaturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Temperatura oTemperatura)
        {
            switch (ValidarDatos(oTemperatura))
            {
                case 1:
                    return BadRequest("El objeto es nulo");
                    break;
                case 2:
                    return BadRequest("El identificador de la temperatura debe ser mayor a cero");
                    break;
                case 3:
                    return BadRequest("La temperatura debe oscilar entre -70° y 70°");
                    break;
            }
            int x = TempSingletton.getInstance().ActualizarTemp(oTemperatura);
            if (x == 1)
            {
                return Ok("Se actualizo correctamente");
            }
            return BadRequest("Intente de nuevo mas tarde, porfavor.");
        }

        // DELETE api/<TemperaturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) { return BadRequest("El identificador asociado a la temperatura debe ser mayor a 0"); }
            int x = 0;
            x = TempSingletton.getInstance().EliminarTemp(id);
            if (x > 0)
            {
                return Ok("Se elimino correctamente la temperatura");
            }
            return NotFound("No se encontro la medicion asociado al identificador ingresado");
        }
    }
}
