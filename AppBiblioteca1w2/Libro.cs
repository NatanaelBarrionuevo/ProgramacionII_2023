using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Libro :Publicacion
    {
        private int isbn;
        private Autor autor;

        public int pIsbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public Autor pAutor
        {
            get { return autor; }
            set { autor = value; }
        }

        public Libro() :base()
        {
            isbn = 0;
            autor = null; //new Autor();
        }
        public Libro(int isbn, string titulo, Autor autor, int paginas)
               :base(titulo, paginas)
        {
            this.isbn = isbn;
            this.autor = autor;
        }

        //public string mostrarLibro()
        //{
        //    string aux = "";

        //    aux += "| ISBN: " + isbn 
        //        + " | Título: " + titulo 
        //        + " | Autor: " + autor.ToString() 
        //        + " | Páginas: " + paginas;

        //    return aux;
        //}
        public override string ToString()
        {
            return "| ISBN: "+isbn+" | Autor: "+autor.ToString()+base.ToString();
        }
    }
}
