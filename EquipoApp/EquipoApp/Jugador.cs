using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoApp
{
    public class Jugador :Persona
    {
        private string posicion;

        private bool estaLesionado;

        private int faltas;
        public int Faltas
        {
            get { return faltas; }
            set { faltas = value; }
        }

        public bool EstaLesionado
        {
            get { return estaLesionado; }
            set { estaLesionado = value; }
        }

        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public Jugador() : base()
        {

            //llamo primero al constructor de la clase base
            estaLesionado = false;
            faltas = 0;
            posicion = "Sin definir";
        }
        public override string ToString()
        {
            string lesionado;
            //string lesionado = estaLesionado ? "SI" : "NO";

            if (estaLesionado == true) //IDEM if(estaLesionado)
            {
                lesionado = "SI";
            }
            else
            {
                lesionado = "NO";
            }

            return base.ToString() + " | Juega de: " + posicion + " | Faltas(" + faltas + ")" + " | Lesionado? " + lesionado;
        }

        public override int Valoracion()
        {
            return (faltas == 0 && !estaLesionado) ? 10 : 5;
        }
    }
}
