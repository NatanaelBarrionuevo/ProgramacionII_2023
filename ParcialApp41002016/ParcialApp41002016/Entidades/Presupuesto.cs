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

        public int Cod_presupuesto { get { return cod_presupuesto; } set { cod_presupuesto = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        public string Cliente { get { return cliente; } set { cliente = value; } }

        public double Monto { get { return monto; } set { monto = value; } }

        public double Descuento { get { return descuento; } set { descuento = value; } }

        public bool Activo { get { return activo; } set { activo = value; } }

        public DateTime Fecha_baja { get { return fecha_baja; } set { fecha_baja = value; } }

        public List<DetallePresupuesto> Detalle { get { return detalle; } set { detalle = value; } }
        public Presupuesto()
        {
            cliente = string.Empty;
            monto = 0;
            fecha = DateTime.MinValue;
            detalle = new List<DetallePresupuesto>();
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
            foreach (DetallePresupuesto dt in Detalle)
            {
                total += dt.CalcularSubtotales();
                
            }

            return total;
        }

        public void AgregarDetalle(DetallePresupuesto dt)
        {
            Detalle.Add(dt);
        }
        public void QuitarDetalle(int indice)
        {
            Detalle.RemoveAt(indice);//BUSCAR EL ULTIMO, FIFO.
        }
    }
}
