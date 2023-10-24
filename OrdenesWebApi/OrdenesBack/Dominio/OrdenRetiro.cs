using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Dominio
{
    public class OrdenRetiro
    {
        public int Nro { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public List<DetalleOrden> Detalle { get; set; }

        public OrdenRetiro()
        {
            
            Detalle = new List<DetalleOrden>();
        }

        public OrdenRetiro(int nro, DateTime fecha, string resp, List<DetalleOrden> lst)
        {
            Nro = nro;
            Fecha = fecha;
            Responsable = resp;
            Detalle = lst;
        }

        public void AgregarDetalle(DetalleOrden det)
        {
            Detalle.Add(det);
        }

        public void QuitarDetalle(int indice)
        {
            Detalle.RemoveAt(indice);
        }

    }
}
