using FacturacionApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Datos.DTOs;

namespace FacturacionApp.Servicios.Interfaz
{
    public interface IServicio
    {
        List<Provincia> ObtenerProvincias();
        List<BarrioDTO> ObtenerBarrios(Provincia oProvincia);
        
    }
}
