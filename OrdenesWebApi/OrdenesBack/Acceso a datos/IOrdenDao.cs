using OrdenesBack.Acceso_a_datos.DTOs;
using OrdenesBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Acceso_a_datos
{
    interface IOrdenDao
    {

        List<Material> GetMateriales();
        bool Save(OrdenRetiroDTO oOrden);

    }
}
