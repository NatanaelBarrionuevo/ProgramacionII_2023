using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Revista :Publicacion
    {
        private int codigo;

        public int pCodigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Revista() :base()
        {
            codigo= 0;
        }
        public Revista(string titulo, int paginas, int codigo)
               :base(titulo,paginas)
        {
            this.codigo = codigo;
        }

        public override string ToString()
        {
            return "| Código: "+codigo+base.ToString();
        }
    }
}
