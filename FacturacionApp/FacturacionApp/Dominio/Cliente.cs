using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Dominio
{
    public class Cliente
    {
		private int legajo;
		private string apelldio;
		private string nombre;
		private string direccion;
		private Barrio barrio;
		private double telefono;
		private string email;
		private DateTime fecha_alta;
		private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public DateTime Fecha_alta
		{
			get { return fecha_alta; }
			set { fecha_alta = value; }
		}


		public string Email
		{
			get { return email; }
			set { email = value; }
		}


		public double Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}


		public Barrio Barrio
		{
			get { return barrio; }
			set { barrio = value; }
		}


		public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}


		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


		public string Apellido
		{
			get { return apelldio; }
			set { apelldio = value; }
		}


		public int Legajo
		{
			get { return legajo; }
			set { legajo = value; }
		}

	}
}
