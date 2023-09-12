using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Facturas
    {
        private int nroFactura;
        private string fecha;
        private string cliente;
        private double monto;
        formaPagos formaPago;
        private List<detalleFacturas> detalle;


        public int NroFactura { get { return nroFactura; } set { nroFactura = value; } }
        public string Fecha { get { return fecha; } }
        public string Cliente { get; set; }
        public double Monto { get { return monto; } }
        public formaPagos FormaPago { get; set; }
        public List<detalleFacturas> Detalle { get; set; }

        public Facturas()
        {
            detalle = new List<detalleFacturas>();
        }
        public void AgregarDetalle(detalleFacturas nuevoDetalle)
        {
            detalle.Add(nuevoDetalle);
        }
        public void QuitarDetalle(int posicion)
        {
            detalle.RemoveAt(posicion);
            
        }
        public double CalcularTotal()
        {
            double total = 0;


            foreach (detalleFacturas d in detalle)
            {
                total += d.CalcularSubtotal();
            }
            return total;

        }
    }
}
