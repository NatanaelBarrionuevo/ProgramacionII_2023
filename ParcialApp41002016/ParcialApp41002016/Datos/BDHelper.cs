using ParcialApp41002016.Entidades;
using ParcialApp41002016.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.XPath;

namespace ParcialApp41002016.Servicios
{
    public class BDHelper
    {
        //private static BDHelper instancia;
        private SqlConnection conexion;
        private SqlCommand cmd;

        /*private BDHelper() { }*/

        public BDHelper()
        {
            conexion = new SqlConnection(Properties.Resources.cnnstring1);


        }

        /*public static BDHelper ObetenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new BDHelper();
                return instancia;
            }
        }*/
        public int ObtenerId(string SP)
        {
            conexion.Open();
            cmd = new SqlCommand(SP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@next", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            conexion.Close();
            if(Convert.ToInt32(param.Value) == 0)
            {
                param.Value = 1;
            }
            return Convert.ToInt32(param.Value);
        }
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            cmd = new SqlCommand(nombreSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable Consultar(string SP, List<Parametros> parametro)
        {

            conexion.Open();
            cmd = new SqlCommand(SP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            foreach (Parametros p in parametro)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public bool AgregarMaestroDetalle(string SP_P, Presupuesto oP, string SP_D)
        {
            SqlTransaction t = null;
            bool x = true;

            try
            {
                conexion.Open();

                t = conexion.BeginTransaction();

                cmd = new SqlCommand(SP_P, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cliente", oP.Cliente);
                cmd.Parameters.AddWithValue("@dto", oP.Descuento);
                cmd.Parameters.AddWithValue("@total", oP.Monto);
                //cmd.Parameters.AddWithValue("@fecha", oP.Fecha.ToString());                

                SqlParameter p = new SqlParameter("@presupuesto_nro", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                int cod_presupuesto = (int)p.Value;

                SqlCommand cmdDetalle;
                int cod_detalle = 1;

                foreach (DetallePresupuesto detallePresupuesto in oP.Detalle)
                {
                    cmdDetalle = new SqlCommand(SP_D, conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("presupuesto_nro", cod_presupuesto);
                    cmdDetalle.Parameters.AddWithValue("@detalle", cod_detalle);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", detallePresupuesto.Articulo.Cod_articulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detallePresupuesto.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    cod_detalle++;
                }

                t.Commit();
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback();
                    x = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return x;
        }
        public bool BajaPresupuesto(int presupuesto_nro)
        {
            SqlTransaction t = null;
            bool resultado = true;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand("SP_ELIMINAR_PRESUPUESTO", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@presupuesto_nro", presupuesto_nro);
                cmd.ExecuteNonQuery();

                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;
        }

        public bool Modificar(string SP, List<Parametros> lista)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametros p in lista) { cmd.Parameters.AddWithValue(p.Key, p.Value); }
                cmd.ExecuteNonQuery();


                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resultado;
        }

        public bool AgregarDetalle(string SP, int cod_presupuesto, Presupuesto oP)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();

                int cod_detalle = 1;

                foreach (DetallePresupuesto detallePresupuesto in oP.Detalle)
                {
                    cmd = new SqlCommand(SP, conexion, t);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("presupuesto_nro", cod_presupuesto);
                    cmd.Parameters.AddWithValue("@detalle", cod_detalle);
                    cmd.Parameters.AddWithValue("@id_producto", detallePresupuesto.Articulo.Cod_articulo);
                    cmd.Parameters.AddWithValue("@cantidad", detallePresupuesto.Cantidad);
                    cmd.ExecuteNonQuery();
                    cod_detalle++;
                }

                t.Commit();

            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) { conexion.Close(); }
            }
            return resultado;
        }

        public bool ModificarPresupuesto(Presupuesto oPresupuesto)
        {
            bool ok = true;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd.Connection = conexion;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                cmd.Parameters.AddWithValue("@total", oPresupuesto.Monto);
                cmd.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.Cod_presupuesto);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.Cod_presupuesto);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Articulo.Cod_articulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return ok;
        }
        public bool BajaProducto(string SP, int cod_producto)
        {
            SqlTransaction t = null;
            bool resultado = true;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", cod_producto);
                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (Exception ex) { if (t != null) { t.Rollback(); } resultado = false; }
            finally { if (conexion != null && conexion.State == ConnectionState.Open) { conexion.Close(); } }
            return resultado;
        }

        public bool AgregarProducto(string SP, Articulo a)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@n_producto", a.Nombre);
                cmd.Parameters.AddWithValue("@precio", a.Precio);
                cmd.Parameters.AddWithValue("@activo", "S");
                int aux = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resultado;

        }

        public bool ModificarProducto(string SP, Articulo a)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", a.Cod_articulo);
                cmd.Parameters.AddWithValue("@n_producto", a.Nombre);
                cmd.Parameters.AddWithValue("@precio", a.Precio);
                cmd.Parameters.AddWithValue("@activo", "S");
                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) { conexion.Close(); }
            }
            return resultado;
        }

        public bool EliminarCliente(string SP, int legajo)
        {
            SqlTransaction t = null;
            bool resultado = true;
            try
            {
                conexion.Open();
                t  = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch(Exception ex)
            {
                if(t != null)
                {
                    t.Rollback();
                }
                resultado = false;
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open) { conexion.Close(); }
            }
            return resultado;
        }

        public bool AgregarCliente(string SP, Clientes c)
        {
            SqlTransaction t = null;
            bool resultado = true;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd = new SqlCommand(SP, conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@legajo", c.Legajo);
            }
            return resultado;
        }
    }
}