using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Entidades
{
    public class DetalleOrden
    {
        private int codigo;
        private Material material;
        private int cantidad;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public Material Material { get { return material; } set { material = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }
        public DetalleOrden(Material material, int cantidad)
        {
            this.material = material;
            this.cantidad = cantidad;
        }
    }
}
