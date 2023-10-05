using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Entidades
{
    public class Material
    {
        private int codigo;
        private string nombre;
        private int cantidad;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public Material(int codigo, string nombre, int stock)
        {
            this.codigo = codigo;
            Nombre = nombre;
            Cantidad = stock;
        }
    }
}
