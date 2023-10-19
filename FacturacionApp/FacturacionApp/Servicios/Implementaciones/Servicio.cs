using FacturacionApp.Datos.Implementaciones;
using FacturacionApp.Datos.Interfaz;
using FacturacionApp.Dominio;
using FacturacionApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Datos.DTOs;
namespace FacturacionApp.Servicios.Implementaciones
{
    public class Servicio : IServicio
    {
        private IFacturaDao dao;

        public Servicio()
        {
            dao = new FacturaDao();
        }

        public List<Provincia> ObtenerProvincias()
        {
            return dao.ConsultarProvincias();
        }

        public List<BarrioDTO> ObtenerBarrios(Provincia oProvincia)
        {
            return dao.ConsultarBarrios(oProvincia);
        }
    }
}
