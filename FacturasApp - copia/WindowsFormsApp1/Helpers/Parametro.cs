using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Helpers
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public Object Valor { get; set; }

        public Parametro(string Nombre, Object value)
        {
            Nombre = this.Nombre;
            Valor = this.Valor;

        }
    }
}
