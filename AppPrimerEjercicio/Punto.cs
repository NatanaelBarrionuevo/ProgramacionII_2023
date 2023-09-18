using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppPrimerEjercicio
{
     class Punto
    {
        private float x, y;

        public Punto()
        {
            x = 1;
            y = 1;
        }

        //Constructores: Permiten inicializar los atributos cuando se crea el objeto
        //Métodos de Acceso o Modificadores: (PROPERTY): pernuten acceder y/o modificar los atributos

        //Metodos propios:
        public double CalcularDistanciaOrigen()
        {
            
            //Casteo explícito
            float hipotenusa =  (float)Math.Sqrt(x * x + y * y);
            return hipotenusa;
        }

    }
}
