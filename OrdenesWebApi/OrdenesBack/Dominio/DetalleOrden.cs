using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Dominio
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public DetalleOrden()
        {
            Material = new Material();
        }

        public DetalleOrden(int id, Material mat, int cant)
        {
            Id = id;
            Material = mat;
            Cantidad = cant;
        }

        public override string ToString()
        {
            return "Id: "+ Id + "\n Material: " + Material;
        }
    }
}
