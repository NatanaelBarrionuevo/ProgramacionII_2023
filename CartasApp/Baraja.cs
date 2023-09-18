using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasApp
{
    public class Baraja
    {
        private Carta[] cartas;
        private int ultimaCarta;

        public Baraja()
        {
            cartas = new Carta[54]; //NO TENGO 54 CARTAS, tengo un arreglo de 54 flechas nulas
            ultimaCarta = 0;
            Inicializar();
        }

        private void Inicializar()
        {
            string[] palos = { "♥", "♠", "♦", "♣" };
            char[] valores = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', '1', 'J', 'Q', 'K' };
            int k = 0;

            for (int i = 0; i < palos.Length; i++)
            {
                for (int j = 0; j < valores.Length; j++)
                {
                    if (Char.IsDigit(valores[j]))
                    {
                        if (valores[j] == '1')
                        {
                            cartas[k] = new Numerica(10, palos[i]);
                        }
                        else
                        {
                            cartas[k] = new Numerica(int.Parse(valores[j].ToString()), palos[i]);
                        }
                    }
                    else
                    {
                        cartas[k] = new ConLetra(palos[i], valores[j]);
                    }

                    k++;
                }//primer for:
            }//segundo for:

            cartas[k++] = new Comodin(2);
            cartas[k] = new Comodin(2);
        }

        public string MostrarMazo()
        {
            string aux = "";
            for (int i = 0; i < cartas.Length; i++)
            {
                aux += cartas[i].ToString() + "\n";
            }
            return aux;
        }

        public int ValorMazo()
        {
            int aux = 0;
            for (int i = 0; i < cartas.Length; i++)
            {
                aux += cartas[i].Valor();
            }
            return aux;
        }

        public void Barajar()
        {
            Random r;
            for (int i = 0; i < cartas.Length; i++)
            {
                r = new Random();
                int pos = r.Next(cartas.Length); //valor aleatorio entre [0, 54)

                Carta c = cartas[i];
                cartas[i] = cartas[pos];
                cartas[pos] = c;
            }
        }

    }
}
