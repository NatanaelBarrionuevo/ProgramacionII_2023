using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class detalleFacturas
    {
        
        private Articulos articulo;
        private double precio_venta;
        private int cantidad;



        public Articulos Articulo { get { return articulo; } }
        public double Precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public detalleFacturas(Articulos articulo, double precio, int cantidad)
        {
            this.articulo = articulo;
            precio_venta = CalcularPrecio(precio);
            this.cantidad = cantidad;
        }

        public double CalcularSubtotal()
        {
            return Cantidad * (articulo.Precio * 1.3);
        }
        public double CalcularPrecio()
        {
            return Articulo.Precio * 1.3;
        }
        public double CalcularPrecio(double precio)
        {
            return precio * 1.3;
        }
    }
}
