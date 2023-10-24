using OrdenesBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Acceso_a_datos.DTOs
{
    public class OrdenRetiroDTO
    {
        public string Responsable { get; set; }
        public List<DetalleOrdenDTO> Detalle { get; set; }

        public OrdenRetiroDTO()
        {
             Detalle = new List<DetalleOrdenDTO>();
        }
        public OrdenRetiroDTO(string resp, List<DetalleOrdenDTO> lst)
        {
            Responsable = resp;
            Detalle = lst;
        }
    }
}
