using OrdenesBack.Acceso_a_datos.DTOs;
using OrdenesBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Negocio.Interfaz
{
    public interface IAplicacion
    {
        List<Material> ConsultarMateriales();
        bool CrearOrden(OrdenRetiroDTO oOrden);
    }
}
