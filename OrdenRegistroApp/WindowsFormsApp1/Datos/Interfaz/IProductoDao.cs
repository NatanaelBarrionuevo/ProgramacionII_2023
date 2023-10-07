using System;
using OrdenRetiro.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdenRetiro.Entidades.DTOs;

namespace OrdenRetiro.Datos.Interfaz
{
    public interface IProductoDao
    {
        List<DTOMaterial> ConsultarMateriales();
        int InsertarOrden(Orden oOrden);
    }
}
