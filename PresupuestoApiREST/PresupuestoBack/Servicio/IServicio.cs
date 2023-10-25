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
        bool AgregarPresupuesto(Presupuesto oPresupuesto);
        bool ModificarPresupuesto(Presupuesto oPresupuesto);
        bool EliminarPresupuesto(int id);
    }
}
