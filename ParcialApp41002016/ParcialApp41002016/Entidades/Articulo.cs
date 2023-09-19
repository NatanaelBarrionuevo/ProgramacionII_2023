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

        public int Cod_articulo { get { return codigo_articulo; } set { codigo_articulo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }

        public double Precio { get { return precio; } set { precio = value; } }

        public bool Activo { get { return activo; } set { activo = value; } }

        public Articulo(int cod_articulo, string nombre, double precio)
        {
            this.codigo_articulo = cod_articulo;
            this.nombre = nombre;
            this.precio = precio;
            activo = true;
        }

        public override string ToString()
        {
            return Nombre; 
        }
    }
}
