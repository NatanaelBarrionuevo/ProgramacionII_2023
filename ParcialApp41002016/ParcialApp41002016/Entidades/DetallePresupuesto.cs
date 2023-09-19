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

        public int Cod_presupuesto { get { return cod_presupuesto; } set { cod_presupuesto = value; } }
        public int Cod_detalle { get { return cod_detalle; } set { cod_detalle = value; } }
        public Articulo Articulo { get { return articulo; } set { articulo = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        public DetallePresupuesto(int cod_presuuesto, Articulo articulo, int cantidad)
        {
            this.cod_presupuesto = cod_presuuesto;
            
            //lista.Add(articulo);
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
        /*
        public double PrecioVenta()
        {
            return Articulo.Precio * 1.3;
        }*/
        public double CalcularSubtotales()
        {
            return Articulo.Precio * 1.3 * Cantidad;
        }

    }
}
