using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp41002016.Entidades
{
    public class Clientes
    {
		private int legajo;
		private string nombre;
        private string apellido;
        private string barrio;
        private string domicilio;
        private int altura;
        private int telefono;
        private string mail;
        private DateTime fecha_nac;
        private DateTime fecha_alta;
        private bool activo;

        public int Legajo { get { return legajo; } set { legajo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string Barrio { get { return barrio; } set { barrio = value; } }
        public string Domicilio { get { return domicilio; } set { domicilio = value; } }
        public int Altura { get { return altura; } set { altura = value; } }
        public int Telefono { get { return telefono; } set { telefono = value; } }
        public string Mail { get { return mail; } set { mail = value; } }
        public DateTime Fecha_nac { get { return fecha_nac; } set { fecha_nac = value; } }
        public DateTime Fecha_alta { get { return fecha_alta; } set { fecha_alta = value; } }
        public bool Activo { get { return activo; } set { activo = value; } }

        public Clientes()
        {
                
        }

        
        public double CalcularFidelidad()
        {
            return Convert.ToDouble(DateTime.Now - fecha_alta);
        }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }

    }
}
