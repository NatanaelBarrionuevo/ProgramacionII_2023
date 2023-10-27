using CarpinteriaBack.Datos.DTOs;
using PresupuestoBack.Datos.DTOs;
using PresupuestoBack.Datos.Implementaciones;
using PresupuestoBack.Datos.Interfaz;
using PresupuestosBack.Datos;
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
            return dao.GetAllProductos();
        }

        public bool AgregarPresupuesto(PresupuestoDTO oPresupuesto)
        {
            return dao.InsertarPresupuesto(oPresupuesto);
        }

        public bool ModificarPresupuesto(PresupuestoDTO oPresupuesto)
        {
            return dao.ActualizarPresupuesto(oPresupuesto);
        }

        public bool EliminarPresupuesto(int id)
        {
            return dao.EliminarPresupuesto(id);
        }

        public List<Presupuesto> ObtenerPresupuestos()
        {
            throw new NotImplementedException();
        }

        public List<PresupuestoDTO> ObtenerPresupuestos(List<Parametro> lst)
        {
            return dao.GetPresupuesto(lst);
        }

        public PresupuestoDTO ObtenerDetalles(List<Parametro> lst)
        {
            throw new NotImplementedException();
        }
    }
}
