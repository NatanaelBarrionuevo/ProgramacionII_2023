using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Datos.DTOs
{
    public class ProvinciaDTO
    {
        public string Nombre { get; set; }
        public ProvinciaDTO(string nombre)
        {
            Nombre = nombre;
        }
    }
}
