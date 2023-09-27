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
        private int barrio;
        private string domicilio;
        private int altura;
        private int telefono;
        private string mail;
        private DateTime fecha_nac;        
        private bool activo;
        private string sexo;
        private DateTime fec_alta;
        private DateTime fec_baja;

        public int Legajo { get { return legajo; } set { legajo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public int Barrio { get { return barrio; } set { barrio = value; } }
        public string Domicilio { get { return domicilio; } set { domicilio = value; } }
        public int Altura { get { return altura; } set { altura = value; } }
        public int Telefono { get { return telefono; } set { telefono = value; } }
        public string Mail { get { return mail; } set { mail = value; } }
        public DateTime Fecha_nac { get { return fecha_nac; } set { fecha_nac = value; } }        
        public bool Activo { get { return activo; } set { activo = value; } }

        public string Sexo { get { return sexo; } set { sexo = value; } }   

        public DateTime Fec_alta { get { return fec_alta; } set { fec_alta = value; } }

        public DateTime Fec_baja { get { return fec_baja; } set { fec_baja = value; } }
        public Clientes()
        {
                
        }

        
        public double CalcularFidelidad()
        {
            
            return Convert.ToDouble(DateTime.Now - Convert.ToDateTime(Fec_alta));
        }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }

    }
}
