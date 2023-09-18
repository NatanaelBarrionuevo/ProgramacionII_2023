using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoApp
{
    public class Equipo
    {
        private string categoria;
        private Persona[] personas;
        private int siguiente;

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Equipo(int total)
        {
            categoria = "S/D";
            personas = new Persona[total];
            siguiente = 0;
        }

        /*public void AgregarPersona(Persona persona)
        {
            if (siguiente < personas.Length)
            {
                personas[siguiente] = persona;
                siguiente++;
            }

           // ListarIntegrantes();
        }*/

        public void AgregarPersona(Persona persona)
        {
            if (persona != null)
            {
                for (int i = 0; i < personas.Length; i++)
                {
                    if (personas[i] == null)
                    {
                        //encuentro un lugar vacío, guardo y salgo
                        personas[i] = persona;
                        break;
                    }

                }
            }



            // ListarIntegrantes();
        }



        //Completar:


        /// <summary>
        /// Permite retornar una cadena con el listado completo de todos los integrantes de un equipo, 
        /// tanto jugadores como entrenadores.
        /// </summary>

        public string ListarIntegrantes()
        {
            string aux = "";
            //StringBuilder sb = new StringBuilder();


            for (int i = 0; i < personas.Length  ; i++)
            {
                if (personas[i] != null)
                {
                    //sb.Append(personas[i].ToString());
                    //sb.Append("\n");
                    aux += personas[i].ToString() + "\n";//polimorfismo
                }
            }

            return aux;
            //return sb.ToString();
        }


        /// <summary>
        /// Permite retornar un valor entero correspondiente a la cantidad de jugadores cuya posición y valoración  
        /// se reciben como parámetros
        /// </summary>
        /// <param name="posicion">Posición del jugador</param>
        /// <param name="valor">Indicador de valoración del jugador</param>
        /// <returns>Cantidad de jugadores de la posición recibida con una valoración igual o superior al segundo parámetro</returns>

        public int JugadoresConPosicionValorados(string posicion, int valor)
        {
            int contador = 0;

            foreach (Persona item in personas)
            {
                if( item != null)
                {

                    //item.GetType().Equals(typeof(Jugador));
                    if(item is Jugador) //chequeo de tipos
                    {
                       
                        Jugador j = (Jugador)item; // puedo castear al tipo específico!!!

                        if(j.Posicion.Equals(posicion) && j.Valoracion() >= valor)
                        {
                            contador++;
                        }

                    }
                }
            }
            
            return contador;
        }

        public Persona PersonaFavorita()
        {
            Persona may = null;

            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i] != null)
                {

                    if (may == null || personas[i].Valoracion() >= may.Valoracion() )
                    {
                        may = personas[i];
                    }

                }
            }


            return may;
        }




    }
}
