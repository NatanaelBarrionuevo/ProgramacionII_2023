using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasApp
{
    public class Numerica : Carta // hereda de carta
    {
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Numerica(int numero, string palo): base(palo)
        {
            this.numero = numero;
        }

        //Por ser una carta estoy obligado a tener este comportamiento no abstracto
        public override int Valor()
        {
            return numero * 10;
        }

        public override string ToString()
        {
            return numero.ToString() + " " + base.ToString();
        }
    }
}
