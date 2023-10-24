using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Acceso_a_datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametro(string n, object v)
        {
            Nombre = n;
            Valor = v;
        }
    }
}

