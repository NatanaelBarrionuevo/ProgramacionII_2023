using OrdenesBack.Acceso_a_datos.DTOs;
using OrdenesBack.Dominio;
using ParcialApp.Acceso_a_datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrdenesBack.Acceso_a_datos
{
    internal class OrdenDao : IOrdenDao
    {
        public List<Material> GetMateriales()
        {
            List<Parametro> lst = null;
            DataTable tabla = HelperDao.getInstancia().Select("SP_CONSULTAR_MATERIALES", lst);
            List<Material> list = new List<Material>();
            Material mat;
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    int id = Convert.ToInt32(fila.ItemArray[0]);
                    string nombre = fila.ItemArray[1].ToString();
                    int stock = Convert.ToInt32(fila.ItemArray[2]);

                    mat = new Material(id, nombre, stock);
                    list.Add(mat);
                }
            }
            return list;
        }



        public bool Save(OrdenRetiroDTO oOrden)
        {
            List<Parametro> lst = new List<Parametro>() { new Parametro("@responsable", oOrden.Responsable) };
            int aux = HelperDao.getInstancia().Insert("SP_INSERTAR_ORDEN", lst, "@nro");
            List<Parametro> list;
            int n = 0;
            int cod = 1;
            foreach (DetalleOrdenDTO x in oOrden.Detalle)
            {
                list = new List<Parametro>()
                {
                    new Parametro("@nro_orden", aux),
                    new Parametro("@detalle", cod),
                    new Parametro("@codigo", x.Material.Codigo),
                    new Parametro("@cantidad", x.Cantidad)
                };
                n += HelperDao.getInstancia().Insert("SP_INSERTAR_DETALLES", list, "");
                cod++;
            }
            if( n == oOrden.Detalle.Count )
            {
                return true;
            }
            return false;
        }
    }
}
