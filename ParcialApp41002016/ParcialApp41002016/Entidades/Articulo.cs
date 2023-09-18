using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParcialApp41002016.Entidades
{
    public class Articulo
    {
        private int codigo_articulo;
        private string nombre;
        private double precio;
        private bool activo;

        public int Cod_articulo { get; set; }
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public bool Activo { get; set; }

        public Articulo(int cod_articulo, string nombre, double precio)
        {
            this.codigo_articulo = cod_articulo;
            this.nombre = nombre;
            this.precio = precio;
            activo = true;
        }
    }
}
