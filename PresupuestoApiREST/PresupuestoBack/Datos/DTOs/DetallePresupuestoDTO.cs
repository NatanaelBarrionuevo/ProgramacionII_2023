using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Datos.DTOs
{
    public class DetallePresupuestoDTO
    {

        public string NProducto { get; set; }
        public double Precio { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public DetallePresupuestoDTO()
        {

        }

    }
}
