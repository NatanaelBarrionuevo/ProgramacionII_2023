using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Publicacion
    {
        private string titulo;
        private int paginas;

        public string pTitulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public int pPaginas
        {
            get { return paginas; }
            set { paginas = value; }
        }

        public Publicacion()
        {
            titulo = string.Empty;
            paginas = 0;
        }
        public Publicacion(string titulo, int paginas)
        {
            this.titulo = titulo;
            this.paginas = paginas;
        }

        public override string ToString()
        {
            string aux = "";

            aux += " | Título: " + titulo
                 + " | Páginas: " + paginas;

            return aux;
        }
    }
}
