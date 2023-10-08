using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Datos.DTOs
{
    public class BarrioDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Provincia { get; set; }

        public BarrioDTO(int codigo, string nombre, int provincia)
        {
            Codigo = codigo;
            Nombre = nombre;
            Provincia = provincia;
        }
    }
}
