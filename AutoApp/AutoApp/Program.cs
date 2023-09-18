using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Crear un automovil:

            Auto oAuto = new Auto(5000, 10);
            oAuto.CargarCombustible(10);
            string mensaje = oAuto.Conducir(100) ? "100 km recorridos!" : "SIN COMBUSTIBLE PARA 100km";
            Console.WriteLine(mensaje);
        }
    }
}
