using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w1
{
    internal class Biblioteca
    {
        private Libro[] estanteria;
        private int ultimo;

        public Biblioteca()
        {
            estanteria = new Libro[10];
            ultimo = 0;
        }
        public Biblioteca(int tamanio )
        {
            estanteria = new Libro[tamanio];
            ultimo = 0;
        }
        public bool agregarLibro(Libro oLibro)
        {
            if (ultimo < estanteria.Length)
            {
                estanteria[ultimo] = oLibro;
                ultimo++;
                return true;
            }
            else
                return false;
        }
        public string mostrarListado()
        {
            string aux = "Listado de libros \n";
            for (int i = 0; i < ultimo; i++)
            {
                aux += estanteria[i].ToString() + "\n";            
            }
            return aux;
        }
        //Tarea    
        public bool quitarLibro()
        {
            //????
            return true;
            
        }
        public Libro mayorCantidadPaginas()
        {
            Libro mayor = estanteria[0];

            for (int i = 0; i < ultimo; i++)
            {
                if (estanteria[i].pPaginas > mayor.pPaginas)
                    mayor = estanteria[i];
            }
            return mayor; 
        }
    }
}
