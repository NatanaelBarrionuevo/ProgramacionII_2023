using FacturacionApp.Datos.Interfaz;
using FacturacionApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionApp.Datos.DTOs;

namespace FacturacionApp.Datos.Implementaciones
{
    public class FacturaDao : IFacturaDao
    {
        public List<Provincia> ConsultarProvincias()
        {
            List<Provincia> lst = new List<Provincia>();
            DataTable tabla = HelperDao.GetInstancia().ConsultarSql("SP_C_PROVINCIAS", new List<Parametro>());
            Provincia provincia;
            foreach (DataRow item in tabla.Rows)
            {
                provincia = new Provincia(Convert.ToInt32(item.ItemArray[0]), item.ItemArray[1].ToString());
                lst.Add(provincia);
            }
            return lst;
        }

        List<Barrio> IFacturaDao.ConsultarBarrios(Provincia provincia)
        {
            List<Barrio> lst = new List<Barrio>();
            DataTable tabla = HelperDao.GetInstancia().ConsultarSql("SP_C_BARRIOS", new List<Parametro>());
            Barrio barrio;
            foreach (DataRow item in tabla.Rows)
            {
                barrio = new Barrio(Convert.ToInt32(item.ItemArray[0]), item.ItemArray[1].ToString(), provincia);
                lst.Add(barrio);
            }
            return lst;
        }
    }
}
