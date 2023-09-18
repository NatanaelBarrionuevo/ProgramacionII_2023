using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Equipo equipoTest = new Equipo(20);
            equipoTest.Categoria = "7 ma TEST";

            Jugador jugador = new Jugador();
            jugador.Posicion = "Defensor";
            jugador.NombreCompleto = "Jugador Test";

            Jugador otroJugador = new Jugador();
            otroJugador.Posicion = "Delantero";
            otroJugador.NombreCompleto = "Jugador Otro Test";

            Entrenador entrenador = new Entrenador("A+", 1, 6);
            entrenador.NombreCompleto = "Entrenador TEST";

            equipoTest.AgregarPersona(jugador);
            equipoTest.AgregarPersona(otroJugador);
            equipoTest.AgregarPersona(entrenador);

            Console.WriteLine("LISTADO DE INTEGRANTES del equipo: \n");
            Console.WriteLine(equipoTest.ListarIntegrantes());

            Persona favorita = equipoTest.PersonaFavorita();
            if(favorita != null)
            {
                Console.WriteLine("\nPERSONA MEJOR VALORADA: " + favorita.ToString());
            }

            Console.WriteLine("Cantidad de defensores con mas de 5 puntos: " + equipoTest.JugadoresConPosicionValorados("Defensor", 5));



            Console.ReadLine();
        }
    }
}
