using PresupuestoBack.Datos.Implementaciones;
using PresupuestoBack.Datos.Interfaz;
using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Servicio
{
    public class Servicio : IServicio
    {
        private IPresupuestoDao dao;

        public Servicio()
        {
            dao = new PresupuestoDao();
        }
        public List<Producto> ObtenerProductos()
        {
            return dao.GetAll();
        }

        public bool AgregarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.InsertarPresupuesto(oPresupuesto);
        }

        public bool ModificarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.ActualizarPresupuesto(oPresupuesto);
        }

        public bool EliminarPresupuesto(int id)
        {
            return dao.EliminarPresupuesto(id);
        }

        
    }
}
