using CarpinteriaBack.Datos.DTOs;
using PresupuestoBack.Datos.DTOs;
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
        public bool ActualizarPresupuesto(PresupuestoDTO dto)
        {
            Presupuesto presupuesto = new Presupuesto();

            presupuesto.Cliente = dto.Cliente;
            presupuesto.Fecha = DateTime.Today.Date;
            presupuesto.Descuento = dto.Descuento;
            presupuesto.CostoMO = dto.CostoMO;

            foreach (DetallePresupuestoDTO detDTO in dto.Detalles)
            {
                Producto producto = GetAllProductos(detDTO.Producto);
                DetallePresupuesto detalle = new DetallePresupuesto(producto, detDTO.Cantidad);
                presupuesto.AgregarDetalle(detalle);
            }

            List<Parametro> lst = new List<Parametro>()
            {
                new Parametro("@cliente", presupuesto.Cliente),
                new Parametro("@dto", presupuesto.Descuento),
                new Parametro("@total", presupuesto.CalcularTotalConDescuento()),
                new Parametro("@presupuesto_nro", presupuesto.PresupuestoNro)
            };

            int ok = HelperDB.ObtenerInstancia().EjecutarSQL("SP_MODIFICAR_MAESTRO", lst);
            int resultado = 0;

            if (ok == 1)
            {
                List<Parametro> list;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in presupuesto.Detalles)
                {
                    list = new List<Parametro>()
                    {
                        new Parametro("@presupuesto_nro", presupuesto.PresupuestoNro),
                        new Parametro("@detalle", detalleNro),
                        new Parametro("@id_producto", item.Producto.ProductoNro),
                        new Parametro("@cantidad", item.Cantidad)
                    };
                    resultado += HelperDB.ObtenerInstancia().EjecutarSQL("SP_INSERTAR_DETALLE", list);
                    detalleNro++;
                }
            }
            if (resultado == presupuesto.Detalles.Count)
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
            if (HelperDB.ObtenerInstancia().EjecutarSQL("SP_ELIMINAR_PRESUPUESTO", lst) == 1)
            {
                return true;
            }
            return false;
        }

        public List<PresupuestoDTO> GetPresupuesto(List<Parametro> lst)
        {
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRESUPUESTOS", lst);
            List<PresupuestoDTO> aux = new List<PresupuestoDTO>();
            if (dt != null)
            {
                PresupuestoDTO p;
                foreach (DataRow fila in dt.Rows)
                {
                    p = new PresupuestoDTO();
                    p.Cliente = fila["cliente"].ToString();
                    p.Fecha = Convert.ToDateTime(fila["fecha"]);
                    p.Nro = Convert.ToInt32(fila["presupuesto_nro"]);
                    p.Total = Convert.ToDouble(fila["Total"]);
                    aux.Add(p);
                }
                return aux;
            }
            return aux;
        }

        public List<Producto> GetAllProductos()
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

        public Producto GetAllProductos(int id)
        {
            DataTable tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTO", new List<Parametro>() { new Parametro("@cod", id) });
            Producto p = null;
            foreach (DataRow fila in tabla.Rows)
            {
                int nro = Convert.ToInt32(fila.ItemArray[0]);
                string nombre = fila.ItemArray[1].ToString();
                double precio = Convert.ToDouble(fila.ItemArray[2]);
                p = new Producto(nro, nombre, precio);

            }
            return p;
        }

        public Presupuesto GetPresupuesto(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertarPresupuesto(PresupuestoDTO dto)
        {
            Presupuesto presupuesto = new Presupuesto();

            presupuesto.Cliente = dto.Cliente;
            presupuesto.Fecha = DateTime.Today.Date;
            presupuesto.Descuento = dto.Descuento;
            presupuesto.CostoMO = dto.CostoMO;

            foreach (DetallePresupuestoDTO detDTO in dto.Detalles)
            {
                Producto producto = this.GetAllProductos(detDTO.Producto);
                DetallePresupuesto detalle = new DetallePresupuesto(producto, detDTO.Cantidad);
                presupuesto.AgregarDetalle(detalle);
            }
            List<Parametro> list = new List<Parametro>()
            {
                new Parametro("@cliente", presupuesto.Cliente),
                new Parametro("@dto", presupuesto.Descuento),
                new Parametro("@total", presupuesto.CalcularTotalConDescuento())
            };
            int ok = HelperDB.ObtenerInstancia().ConfirmarPresupuesto("SP_INSERTAR_MAESTRO", list, "@presupuesto_nro");
            presupuesto.PresupuestoNro = ok;
            int resultado = 0;
            if (ok > 1)
            {
                List<Parametro> lst;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in presupuesto.Detalles)
                {
                    lst = new List<Parametro>()
                    {
                        new Parametro("@presupuesto_nro", presupuesto.PresupuestoNro),
                        new Parametro("@detalle", detalleNro),
                        new Parametro("@id_producto", item.Producto.ProductoNro),
                        new Parametro("@cantidad", item.Cantidad)
                    };
                    resultado += HelperDB.ObtenerInstancia().ConfirmarPresupuesto("SP_INSERTAR_DETALLE", lst, "");
                    detalleNro++;
                }
            }
            if (resultado == presupuesto.Detalles.Count)
            {
                return true;
            }
            return false;
        }

        public List<Presupuesto> GetAllPresupuestos()
        {
            throw new NotImplementedException();
        }

        public PresupuestoDTO ObtenerDetalles(List<Parametro> lst)
        {
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_DETALLES_PRESUPUESTO", lst);

            bool primero = true;

            PresupuestoDTO presupuesto = new PresupuestoDTO();
            DetallePresupuestoDTO d;
            foreach (DataRow fila in dt.Rows)
            {
                //Solo para la primer fila recuperamos los datos del maestro:
                if (primero)
                {
                    presupuesto.Cliente = fila["cliente"].ToString();
                    presupuesto.Fecha = Convert.ToDateTime(fila["fecha"]);
                    presupuesto.Total = Convert.ToDouble(fila["total"]);
                    presupuesto.Descuento = Convert.ToDouble(fila["descuento"].ToString());
                    primero = false;
                }
                d = new DetallePresupuestoDTO();
                d.NProducto = fila["n_producto"].ToString();
                d.Precio = Convert.ToInt32(fila["precio"]);
                d.Cantidad = Convert.ToInt32(fila["cantidad"]);
                presupuesto.AgregarDetalle(d);
            }
            return presupuesto;

        }
    }
}
