using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Datos.DTOs
{
    public class PresupuestoDTO
    {
        public int Nro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double Descuento { get; set; }
        public double CostoMO { get; set; }

        public double Total { get; set; }

        public List<DetallePresupuestoDTO> Detalles { get; set; }

        public PresupuestoDTO()
        {
            Detalles = new List<DetallePresupuestoDTO>();
        }

        public void AgregarDetalle(DetallePresupuestoDTO detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }

    }
}
