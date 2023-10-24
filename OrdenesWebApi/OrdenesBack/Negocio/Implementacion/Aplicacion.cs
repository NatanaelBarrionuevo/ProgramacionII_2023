using OrdenesBack.Acceso_a_datos;
using OrdenesBack.Acceso_a_datos.DTOs;
using OrdenesBack.Dominio;
using OrdenesBack.Negocio.Interfaz;
using ParcialApp.Acceso_a_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Negocio.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private IOrdenDao dao;

        public Aplicacion()
        {
            dao = new OrdenDao();
        }
        public bool CrearOrden(OrdenRetiroDTO oOrden)
        {
            return dao.Save(oOrden);
        }

        public List<Material> ConsultarMateriales()
        {
            return dao.GetMateriales();
        }
    }
}
