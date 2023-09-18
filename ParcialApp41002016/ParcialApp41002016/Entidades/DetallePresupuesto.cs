using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp41002016.Entidades
{
    public class DetallePresupuesto
    {

        private int cod_presupuesto;
        private int cod_detalle;
        //private List<Articulo> lista;
        private Articulo articulo;
        
        private int cantidad;

        public int Cod_presupuesto { get; set; }
        public int Cod_detalle { get; set; }
        public Articulo Articulo {set; get;}
        public int Cantidad { get; set; }

        public DetallePresupuesto(int cod_presuuesto, Articulo articulo, int cantidad)
        {
            this.cod_presupuesto = cod_presuuesto;
            
            //lista.Add(articulo);
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
        public double PrecioVenta()
        {
            return Articulo.Precio * 1.3;
        }
        public double CalcularSubtotales()
        {
            return PrecioVenta() * Cantidad;
        }

    }
}
