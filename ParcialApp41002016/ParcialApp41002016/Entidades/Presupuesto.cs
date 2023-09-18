using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp41002016.Entidades
{
    public class Presupuesto
    {


        private int cod_presupuesto;
        private DateTime fecha;
        private string cliente;
        private double monto;
        private double descuento;
        private bool activo;
        private DateTime fecha_baja;
        private List<DetallePresupuesto> detalle;

        public int Cod_presupuesto { get; set; }
        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public double Monto { get; set; }

        public double Descuento { get; set; }

        public bool Activo { get; set; }

        public DateTime Fecha_baja { get; set; }

        public List<DetallePresupuesto> Detalle { get; set; }
        public Presupuesto()
        {

        }
        public Presupuesto(string cliente, double monto, DateTime fecha)
        {
            this.cliente = cliente;
            this.monto = monto;
            this.fecha = fecha;
            detalle = new List<DetallePresupuesto>();

        }

        public double CalcularTotales()
        {
            double total = 0;
            foreach (DetallePresupuesto dt in detalle)
            {
                total += dt.CalcularSubtotales();
                
            }

            return total;
        }

        public void AgregarDetalle(DetallePresupuesto dt)
        {
            detalle.Add(dt);
        }
        public void QuitarDetalle(int indice)
        {
            detalle.RemoveAt(indice);//BUSCAR EL ULTIMO, FIFO.
        }
    }
}
