using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp_1w3.Datos
{
    internal class Parametros
    {
        public string Nombre { get; set; }
        public object valor { get; set; }

        public Parametros(string nombre, object valor)
        {
            Nombre = nombre;
            this.valor = valor;
        }
    }
}
