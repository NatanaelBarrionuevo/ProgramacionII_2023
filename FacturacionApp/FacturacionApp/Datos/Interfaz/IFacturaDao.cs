using FacturacionApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Datos.DTOs;

namespace FacturacionApp.Datos.Interfaz
{
    public interface IFacturaDao
    {
        List<Provincia> ConsultarProvincias();
        List<Barrio> ConsultarBarrios(Provincia provincia);
        
    }
}
