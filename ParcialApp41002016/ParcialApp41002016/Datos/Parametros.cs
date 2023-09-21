using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp41002016.Servicios
{
    public class Parametros
    {
        private string key;
        private object value;

        public string Key { get; set; }
        public object Value { get; set; }

        public Parametros(string nombre, object valor)
        {
            Key = nombre; 
            Value = valor;
        }
    }
}
