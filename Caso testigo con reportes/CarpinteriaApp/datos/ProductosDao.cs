using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarpinteriaApp.dominio;
namespace CarpinteriaApp.datos
{
    public class ProductosDao : IDaoProductos
    {
        public List<Producto> GetAll() 
        { 
            List<Producto> list= new List<Producto>();
            DataTable tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS");
            Producto aux = null;
            foreach (DataRow item in tabla.Rows)
            {
                aux = new Producto();
                aux.ProductoNro = int.Parse(item["id_producto"].ToString());
                aux.Nombre = item["n_producto"].ToString();
                aux.Precio = Convert.ToDouble(item["precio"].ToString());
                aux.Activo = item["activo"].ToString().Equals("S");//ESA TA CARGADO COMO UN CHAR S EN LA BD
                list.Add(aux);
            }
            return list;
        }

        

    }
}
