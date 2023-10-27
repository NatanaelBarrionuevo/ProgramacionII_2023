using CarpinteriaBack.Datos.DTOs;
using PresupuestoBack.Datos.DTOs;
using PresupuestosBack.Datos;
using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Datos.Interfaz
{
    public interface IPresupuestoDao
    {
        List<Presupuesto> GetAllPresupuestos();
        List<PresupuestoDTO> GetPresupuesto(List<Parametro> lst);
        PresupuestoDTO ObtenerDetalles(List<Parametro> lst);
        List<Producto> GetAllProductos();
        Producto GetAllProductos(int id);
        bool InsertarPresupuesto(PresupuestoDTO oPresupuesto);
        bool ActualizarPresupuesto(PresupuestoDTO oPresupuesto);
        bool EliminarPresupuesto(int id);
    }
}
