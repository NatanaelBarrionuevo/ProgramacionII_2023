using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasApp
{
    public class ConLetra : Carta
    {
        private char letra;
    
        public char Letra
        {
            get { return letra; }
            set { letra = value; }
        }


        public ConLetra(string palo, char letra):base(palo)
        {
            this.letra = letra;
        }

        public override int Valor()
        {
            return (int)letra; // esto devuelve el valor ASCII del caracter
            //return Char.ConvertToUtf32(letra)
        }

        public override string ToString()
        {
            return letra + " " + base.ToString();
        }

    }
}
