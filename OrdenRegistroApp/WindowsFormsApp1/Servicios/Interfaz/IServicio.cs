using OrdenRetiro.Entidades;
using OrdenRetiro.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Servicios.Interfaz
{
    public interface IServicio
    {
        List<DTOMaterial> ObtenerMateriales();
        int InsertarMaestroDetalle(Orden oOrden);
    }
}
