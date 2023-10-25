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
        List<Producto> GetAll();
        bool InsertarPresupuesto(Presupuesto oPresupuesto);
        bool ActualizarPresupuesto(Presupuesto oPresupuesto);
        bool EliminarPresupuesto(int id);
    }
}
