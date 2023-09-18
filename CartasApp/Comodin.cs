using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasApp
{
    public class Comodin : Carta
    {
        private int valorJuego;

        public int ValorJuego
        {
            get { return valorJuego; }
            set { valorJuego = value; }
        }

        public Comodin(int valor): base()
        {
            valorJuego = valor;
        }

        public override int Valor()
        {
            return valorJuego * 100;
        }
    }
}
