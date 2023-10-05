using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Datos
{
    public class Parametro
    {
        private string nombre;
        private object key;

        public object Key
        {
            get { return key; }
            set { key = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Parametro(string nombre, object key)
        {
            this.nombre = nombre;
            this.key = key;
        }
    }
}
