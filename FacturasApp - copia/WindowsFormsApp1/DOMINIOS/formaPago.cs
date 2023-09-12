using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class formaPagos
    {
        private string forma;
        private bool activo;

        public string Forma
        {
            get { return forma; }
            set { forma = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public formaPagos()
        {
            forma = string.Empty;
        }
        public formaPagos(string forma)
        {
            this.forma = forma;
        }
    }
}
