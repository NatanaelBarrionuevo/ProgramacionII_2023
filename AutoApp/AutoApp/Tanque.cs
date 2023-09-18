using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp
{
    class Tanque
    {
        private int nivelActual;
        private const int CAPACIDAD = 49;
        private const int RESERVA = 5;

        public Tanque()
        {
            nivelActual = 0;
        }

        public Tanque(int nivel)
        {
            nivelActual = nivel;
        }


        public int pCapacidad
        {
            get { return CAPACIDAD; }
        }

        public int pReserva
        {
            get { return RESERVA; }
        }


        public int pNivelActual
        {
            get { return nivelActual; }
        }

        public int Cargar(int litros) {
            int aux = nivelActual + litros;
            int capacidadTotal = CAPACIDAD + RESERVA;

            int derramados = 0;
            if (aux <= capacidadTotal)
            {
                nivelActual = aux;
            }
            else
            {
                derramados = aux - capacidadTotal;
                nivelActual = capacidadTotal;
            }

            return derramados;
        }

        public bool Conducir(int lstNecesarios) {
            bool aux = true; // inicialmente suponemos que se pueden recorrer los <km>
            if (lstNecesarios <= nivelActual)
            {
                nivelActual -= lstNecesarios; // equivale a nivelActual = nivelActual - lstNecesarios
            }
            else
            {
                aux = false; // bajamos la bandera
            }

            return aux;
        }


    }
}
