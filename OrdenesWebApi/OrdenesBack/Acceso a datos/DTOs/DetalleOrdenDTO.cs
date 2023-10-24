using OrdenesBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Acceso_a_datos.DTOs
{
    public class DetalleOrdenDTO
    {
        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public DetalleOrdenDTO()
        {
               
        }
    }
}
