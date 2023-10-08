using OrdenRetiro.Datos.Interfaz;
using OrdenRetiro.Entidades;
using OrdenRetiro.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            List<Parametro> listaOrden = new List<Parametro>() { new Parametro("@responsable", oOrden.Responsable) };
            oOrden.CodOrden = BDHelper.ObtenerInstancia().Insertar("SP_INSERTAR_ORDEN", listaOrden, "@nro");
            int resultado = 0;
            int codDet = 1;
            List<Parametro> listaDetalle;
            foreach (DetalleOrden d in oOrden.Detalle)
            {
                Parametro p1 = new Parametro("@nro_orden", oOrden.CodOrden);
                Parametro p2 = new Parametro("@detalle", codDet);
                Parametro p3 = new Parametro("@codigo", d.Material.Codigo);
                Parametro p4 = new Parametro("@cantidad", d.Cantidad);
                listaDetalle = new List<Parametro>() { p1, p2, p3, p4 };
                resultado += BDHelper.ObtenerInstancia().Insertar("SP_INSERTAR_DETALLES", listaDetalle);
                codDet++;
            }

            if (oOrden.CodOrden > 0 && resultado == oOrden.Detalle.Count)
            {
                ok = 1;
            }
            return ok;
        }
    }
}
