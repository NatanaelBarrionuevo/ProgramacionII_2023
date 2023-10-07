using OrdenRetiro.Datos.Implementacion;
using OrdenRetiro.Datos.Interfaz;
using OrdenRetiro.Entidades;
using OrdenRetiro.Entidades.DTOs;
using OrdenRetiro.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IProductoDao dao;

        public Servicio()
        {
                dao = new ProductoDao();
        }
        public int InsertarMaestroDetalle(Orden oOrden)
        {
            return dao.InsertarOrden(oOrden);
        }

        public List<DTOMaterial> ObtenerMateriales()
        {
            return dao.ConsultarMateriales();
        }
    }
}
