using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Biblioteca
    {
        //private Libro[] estanteria; 
        private Publicacion[] estanteria;
        private int ultimo;

        public Biblioteca()
        {
            estanteria = new Publicacion[10];  
            ultimo = 0;
        }
        public Biblioteca(int tamanio)
        {
            estanteria = new Publicacion[tamanio];
            ultimo = 0;
        }
        //public bool agregarLibro(Libro oLibro)
        public bool agregarPublicacion(Publicacion oPublicacion)
        {
            if (ultimo < estanteria.Length)
            {
                estanteria[ultimo] = oPublicacion;
                ultimo++;
                return true;
            }
            else
                return false;
        }

        // Tarea --> quitarLibro()

        public string mostrarListado()
        {
            string aux = "----- LISTADO DE PUBLICACIONES -----\n";

            for (int i = 0; i < ultimo; i++)
            {
                aux += estanteria[i].ToString()+ "\n";
            }
            return aux;
        }
        public string buscarPublicacion(string titulo)
        {
            string aux = "No se encontró "+ titulo;

            for (int i = 0; i < ultimo; i++)
            {
                if (estanteria[i].pTitulo.Equals(titulo)) //(estanteria[i].pTitulo == titulo)
                {
                    aux = estanteria[i].ToString();
                    break;
                }
            }
            return aux;
        }
        public int contarLibros(int paginas)
        {
            int aux = 0;
            foreach (Publicacion p in estanteria)
            {
                if (p != null && p.GetType().Equals(typeof(Libro)) && p.pPaginas > paginas)
                //if (p != null)
                //    if (p.GetType().Equals(typeof(Libro)))
                //        if (p.pPaginas > paginas)
                            aux++;
            }
            return aux;
        }
    }
}
