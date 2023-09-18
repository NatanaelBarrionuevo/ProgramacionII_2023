using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w1
{
    internal class Libro
    {
        private int isbn;
        private string titulo;
        private Autor autor;    //relacion de asociacion 1 a 1 --> Libro "tiene un" Autor
        private int paginas;

        public int pIsbn
        { get { return isbn; } set { isbn = value; } }
        public string pTitulo
        { get { return titulo; } set { titulo = value; } }
        public Autor pAutor
        { get { return autor; } set { autor = value; } }
        public int pPaginas
        { get { return paginas; } set { paginas = value; } }

        public Libro()
        {
            isbn = 0;
            titulo = string.Empty;
            autor = null;
            paginas = 0;
        }
        public Libro(int isbn, string titulo, Autor autor, int paginas)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.paginas = paginas;
        }
        public override string ToString()
        {
            return "ISBN: " + isbn.ToString()
                 + " |Titulo: " + titulo
                 + " |Autor: " + autor.ToString()
                 + " |Paginas: " + paginas;
        }
       
        //Este metodo genera dependencia de la Consola!!!
        //public void mostrarLibro1()
        //{
        //    Console.WriteLine( "ISBN: " + isbn
        //         + " |Titulo: " + titulo
        //         + " |Autor: " + autor
        //         + " |Paginas: " + paginas);
        //}

    }
}
