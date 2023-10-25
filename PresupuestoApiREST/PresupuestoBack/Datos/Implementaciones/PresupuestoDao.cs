using PresupuestoBack.Datos.Interfaz;
using PresupuestosBack.Datos;
using PresupuestosBack.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoBack.Datos.Implementaciones
{
    public class PresupuestoDao : IPresupuestoDao
    {
        public bool ActualizarPresupuesto(Presupuesto oPresupuesto)
        {
            List<Parametro> lst = new List<Parametro>()
            {
                new Parametro("@cliente", oPresupuesto.Cliente),
                new Parametro("@dto", oPresupuesto.Descuento),
                new Parametro("@total", oPresupuesto.CalcularTotalConDescuento()),
                new Parametro("@presupuesto_nro", oPresupuesto.PresupuestoNro)
            };
            int ok = HelperDB.ObtenerInstancia().EjecutarSQL("SP_MODIFICAR_MAESTRO", lst);
            int resultado = 0;
            if (ok == 1)
            {
                List<Parametro> list;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)
                {
                    list = new List<Parametro>()
                    {
                        new Parametro("@presupuesto_nro", oPresupuesto.PresupuestoNro),
                        new Parametro("@detalle", detalleNro),
                        new Parametro("@id_producto", item.Producto.ProductoNro),
                        new Parametro("@cantidad", item.Cantidad)
                    };
                    resultado += HelperDB.ObtenerInstancia().EjecutarSQL("SP_INSERTAR_DETALLE", list);
                    detalleNro++;
                }
            }
            if(resultado == oPresupuesto.Detalles.Count)
            {
                return true;
            }
            return false;
        }

        public bool EliminarPresupuesto(int id)
        {
            List<Parametro> lst = new List<Parametro>() 
            {
                new Parametro("@presupuesto_nro", id)
            };
            if(HelperDB.ObtenerInstancia().EjecutarSQL("SP_ELIMINAR_PRESUPUESTO", lst) == 1)
            {
                return true;
            }
            return false;
        }

        public List<Producto> GetAll()
        {
            DataTable tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS", null);
            Producto p;
            List<Producto> lst = new List<Producto>();
            foreach (DataRow fila in tabla.Rows)
            {
                int nro = Convert.ToInt32(fila.ItemArray[0]);
                string nombre = fila.ItemArray[1].ToString();
                double precio = Convert.ToDouble(fila.ItemArray[2]);
                p = new Producto(nro, nombre, precio);
                lst.Add(p);
            }
            return lst;
        }

        public bool InsertarPresupuesto(Presupuesto oPresupuesto)
        {
            List<Parametro> list = new List<Parametro>()
            {
                new Parametro("@cliente", oPresupuesto.Cliente),
                new Parametro("@dto", oPresupuesto.Descuento),
                new Parametro("@total", oPresupuesto.CalcularTotalConDescuento())
            };
            int ok = HelperDB.ObtenerInstancia().ConfirmarPresupuesto("SP_INSERTAR_MAESTRO", list, "@presupuesto_nro");
            int resultado = 0;
            if (ok > 1)
            {
                List<Parametro> lst;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)
                {
                    lst = new List<Parametro>()
                    {
                        new Parametro("@presupuesto_nro", ok),
                        new Parametro("@detalle", detalleNro),
                        new Parametro("@id_producto", item.Producto.ProductoNro),
                        new Parametro("@cantidad", item.Cantidad)
                    };
                    resultado += HelperDB.ObtenerInstancia().ConfirmarPresupuesto("SP_INSERTAR_DETALLE", lst, "");
                    detalleNro++;
                }
            }
            if (resultado == oPresupuesto.Detalles.Count)
            {
                return true;
            }
            return false;
        }
    }
}
