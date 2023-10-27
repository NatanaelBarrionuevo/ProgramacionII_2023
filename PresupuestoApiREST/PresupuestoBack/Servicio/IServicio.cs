using PresupuestoBack.Datos.DTOs;
using PresupuestosBack.Datos;
using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Servicio
{
    public interface IServicio
    {
        List<Producto> ObtenerProductos();
        List<Presupuesto> ObtenerPresupuestos();
        List<PresupuestoDTO> ObtenerPresupuestos(List<Parametro> lst);
        <PresupuestoDTO ObtenerDetalles(List<Parametro> lst);
        bool AgregarPresupuesto(PresupuestoDTO oPresupuesto);
        bool ModificarPresupuesto(PresupuestoDTO oPresupuesto);
        bool EliminarPresupuesto(int id);
    }
}
