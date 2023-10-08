using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Datos
{
    public class Parametro
    {
		private string nombre;
		private object valor;

		public object Valor
		{
			get { return valor; }
			set { valor = value; }
		}


		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
        public Parametro(string n, object v)
        {
			nombre = n; 
			valor = v;
        }
    }
}
