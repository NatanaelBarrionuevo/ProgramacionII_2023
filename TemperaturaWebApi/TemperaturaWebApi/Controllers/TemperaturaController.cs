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
        public IActionResult GetId(int id, int iot)
        {
            if (id >= 0 && iot > 0)
            {
                List<Temperatura> lst = new List<Temperatura>();
                lst = TempSingletton.getInstance().GetTemp(id, iot);
                if (lst.Count < 0)
                {
                    return NotFound("El identificador ingresado no se ecuentra asociado a ninguna medición");
                }
                return Ok(lst);
            }
            return BadRequest("EL identificador de la medicion de teperatura debe ser mayor a cero. " +
                "\nEn caso de qurer filtrar por el identificador de de dispositivo iot: \nEl identificador de la fecha debe ser igual a cero \nEl identificador del dispositivo, mayor a cero");
        }

        // POST api/<TemperaturaController>
        [HttpPost]
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
                    return BadRequest("El identificador del dispositivo IOT debe ser mayor a cero");
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
            if (oTemperatura.Id <= 0) { n = 2; }
            if (oTemperatura.Iot <= 0) { n = 3; }
            if (oTemperatura.Valor < -70 && oTemperatura.Valor > 70) { n = 4; }
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
                    return BadRequest("El identificador del dispositivo IOT debe ser mayor a cero");
                    break;
                case 4:
                    return BadRequest("La temperatura debe oscilar entre -70° y 70°");
                    break;
            }
            return Ok(TempSingletton.getInstance().EjecutarTemp(oTemperatura));

        }

        // DELETE api/<TemperaturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) { return BadRequest("El identificador asociado a la temperatura debe ser mayor a 0"); }
            List<Temperatura> lst = new List<Temperatura>();
            lst = TempSingletton.getInstance().EjecutarTemp(id);
            if (lst.Count > 0)
            {
                return Ok(lst);
            }
            return NotFound("No se encontro la medicion asociado al identificador ingresado");
        }
    }
}
