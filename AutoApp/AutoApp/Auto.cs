using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp
{
    class Auto
    {
        //atributos:

        private Tanque tanque;
        private int odometro;
        private const int AUTONOMIA = 11;

        //métodos:
        //1-Constructores:
        public Auto()
        {
            tanque = new Tanque(); //donde se ve la relación de asociación entre las clases
            odometro = 0;
        }

        //sobrecarga del constructor:
        public Auto (int odometro, int nivel)
        {
            tanque = new Tanque(nivel);
            this.odometro = odometro;
        }
        
        public int pOdometro
        {
            get { return odometro; }
        }

        //3-De control:
        public int CargarCombustible(int litros) {
            return tanque.Cargar(litros); //delega la responsabilidad al tanque!
        }

        public bool Conducir(int km) {
            int lts = km / AUTONOMIA;
            bool puedeRecorrer = tanque.Conducir(lts);

            if (puedeRecorrer) // if(puedeRecorrer == true)
                odometro += km; // odometro = odometro + km

            return puedeRecorrer;
        }

        public int MostrarNivelActual()
        {
            return tanque.pNivelActual;
        }
    }
}
