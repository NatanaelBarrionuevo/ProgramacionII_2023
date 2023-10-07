using OrdenRetiro.Datos.Interfaz;
using OrdenRetiro.Entidades;
using OrdenRetiro.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Datos.Implementacion
{
    public class ProductoDao : IProductoDao
    {
        public List<DTOMaterial> ConsultarMateriales()
        {
            DataTable tabla = BDHelper.ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            List<DTOMaterial> lista = new List<DTOMaterial>();
            DTOMaterial oProducto;
            foreach (DataRow item in tabla.Rows)
            {
                oProducto = new DTOMaterial();
                oProducto.Codigo = Convert.ToInt32(item.ItemArray[0]);
                oProducto.Nombre = item.ItemArray[1].ToString();
                oProducto.Stock = Convert.ToInt32(item.ItemArray[2]);
                lista.Add(oProducto);
            }
            return lista;
        }       

        public int InsertarOrden(Orden oOrden)
        {
            int ok = -1;
            List<Parametro> lista = new List<Parametro>() { new Parametro("@responsable", oOrden.Responsable) };
            int codigo = BDHelper.ObtenerInstancia().Insertar("SP_INSERTAR_ORDEN", lista, "@nro");
            int resultado = BDHelper.ObtenerInstancia().Insertar("SP_INSERTAR_DETALLES", lista, oOrden.Detalle, "@codigo");

            if (codigo > 0 && resultado == oOrden.Detalle.Count)
            {
                ok = 1;
            }
            return ok;
        }
    }
}
