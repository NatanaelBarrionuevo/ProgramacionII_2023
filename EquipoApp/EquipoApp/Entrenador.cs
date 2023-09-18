using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoApp
{
    public class Entrenador : Persona
    {
        private int cargo; //1:DT |2: PF |3:AC  
        private int antiguedad;

        public int Cargo
        {
            get { return cargo; }
            set { cargo = value; }

        }

        public int Antiguedad
        {
            get { return antiguedad; }
            set { antiguedad = value; }
        }


        public Entrenador(string grupo, int carguito, int antiguedad): base(grupo)
        {
            
            cargo = carguito;
            this.antiguedad = antiguedad;
        }

        public override int Valoracion()
        {
            int valor = 5;

            if (antiguedad > 5)
            {
                valor = valor + (antiguedad - 5);
            }
            else 
            {
               
                if (valor <= 0) { 
                    valor = 0;
                }

            }

            return valor;
        }
        public override string ToString()
        {
           return base.ToString() + " | Cargo: " + CargoToString() + " |Antiguedad: " + antiguedad + " años";
        }

        private string CargoToString()
        {
            //Por defecto se asume que el cargo == 1
            string aux = "DT";

            if (cargo == 2)
                aux = "PF";

            if (cargo == 3)
                aux = "AC";

            return aux;
        }

    }
}
