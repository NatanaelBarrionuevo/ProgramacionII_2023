using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoApp
{
    public abstract class Persona
    {
		private string nombreCompleto;

		private int clase;

		private string grupoSanguineo;

		public string GrupoSanguineo
		{
			get { return grupoSanguineo; }
			set { grupoSanguineo = value; }
		}

		public int Clase
		{
			get { return clase; }
			set { clase = value; }
		}

		public string NombreCompleto
		{
			get { return nombreCompleto; }
			set { nombreCompleto = value; }
		}

		public Persona(string grupo):this()
		{
			grupoSanguineo = grupo;
           
        }

		public Persona()
		{
			clase = 2000;
			nombreCompleto = "S/N";
			grupoSanguineo = "0+";
		}

		public abstract int Valoracion();

		public override string ToString()
		{
			return "Jugador: " + nombreCompleto + " |Clase[" + clase + "] | Grupo sanguíneo: " + grupoSanguineo;
		}

	}
}
