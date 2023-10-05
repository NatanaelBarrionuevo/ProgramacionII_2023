using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Entidades
{
    public class Orden
    {
        private int cod;
        private DateTime fecha;
        private string responsable;
        private List<DetalleOrden> detalle;

        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int CodOrden
        {
            get { return cod; }
            set { cod = value; }
        }

        public List<DetalleOrden> Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        public Orden()
        {
            detalle = new List<DetalleOrden>();
        }

        public void AgregarDetalle(DetalleOrden oDetalle)
        {
            detalle.Add(oDetalle);
        }

        public void  QuitarDetalle(int indice)
        {
            Detalle.RemoveAt(indice);
        }
    }
}
