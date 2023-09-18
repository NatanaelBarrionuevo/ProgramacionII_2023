using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasApp
{
    public abstract class Carta
    {
		private string palo;

        public Carta()
        {
            palo = "None";
        }

        public Carta(string palo)
        {
            this.palo = palo;
        }

        public string Palo
		{
			get { return palo; }
			set { palo = value; }
		}

        public override string ToString()
        {
            if (palo.Equals("None"))
                return "Carta COMODÍN";
            return palo;

            //return (palo.Equals("None") ? "Carta comodín" : palo); Operador ternario
        }
		public abstract int Valor(); // cualquier clase hija SI O SI tiene que tener el comportamiento Valor()


	}
}
