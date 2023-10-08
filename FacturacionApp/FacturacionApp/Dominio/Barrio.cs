using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Dominio
{
    public class Barrio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Provincia Provincia { get; set;}

        public Barrio(int codigo, string nombre, Provincia prov)
        {
            Codigo = codigo; Nombre = nombre; Provincia = prov;
        }
    }
}
