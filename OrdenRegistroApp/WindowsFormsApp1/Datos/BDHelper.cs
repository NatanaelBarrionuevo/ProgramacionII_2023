using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;
using System.Reflection;
using System.Windows.Forms;
using OrdenRetiro.Entidades;

namespace OrdenRetiro.Datos
{
    public class BDHelper
    {
        private static BDHelper instancia;
        private SqlConnection cnn;
        private SqlCommand cmd;
        private BDHelper()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static BDHelper ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new BDHelper();
            }
            return instancia;
        }

        public DataTable Consultar(string sp)
        {
            SqlTransaction t = null;

            DataTable tabla;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandText = sp;

                tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null) { t.Rollback(); }
                tabla = null;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }
            return tabla;

        }
        public DataTable Consultar(string sp, List<Parametro> parameters)
        {
            SqlTransaction t = null;
            DataTable tabla;
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sp, cnn);
                cmd.CommandText = sp;

                foreach (Parametro p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Key);
                }

                tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());

                t.Commit();
            }
            catch
            {
                if (t != null) { t.Rollback(); }
                tabla = null;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }

            return tabla;
        }


        /*public int Insertar(Orden orden)
        {
            SqlTransaction t = null;

            int n = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand("SP_INSERTAR_ORDEN", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@responsable", orden.Responsable);
                SqlParameter param = new SqlParameter("@nro", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                n = cmd.ExecuteNonQuery();

                orden.CodOrden = Convert.ToInt32(param.Value);

                SqlCommand cmdDetalle;
                int codDet = 1;
                foreach (DetalleOrden d in orden.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_orden", orden.CodOrden);
                    cmdDetalle.Parameters.AddWithValue("@detalle", codDet);
                    cmdDetalle.Parameters.AddWithValue("@codigo", d.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    n += cmdDetalle.ExecuteNonQuery();
                    codDet++;
                }

                t.Commit();
            }
            catch (Exception ex) { if (t != null) { t.Rollback(); n = 0; } }

            finally { if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); } }

            return n;
        }*/
       
        public int Insertar(string sp, List<Parametro> lst, string pOut)
        {
            SqlTransaction t = null;
            int n = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Key);
                    }
                }
                SqlParameter param = new SqlParameter(pOut, SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                n = Convert.ToInt32(param.Value);
                t.Commit();
            }
            catch { if (t != null) { t.Rollback(); } n = 0; }
            finally { if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); } }
            return n;
        }
        public int Insertar(string sp, List<Parametro> lst, List<DetalleOrden> detalles, string p)
        {
            SqlTransaction t = null;
            int n = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                int valor = 1;
                if (detalles != null && lst != null)
                {
                    foreach (DetalleOrden d in detalles)
                    {
                        cmd = new SqlCommand(sp, cnn, t);
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (Parametro x in lst)
                        {
                            cmd.Parameters.AddWithValue(x.Nombre, x.Key);
                        }
                        cmd.Parameters.AddWithValue(p, valor);
                        n += cmd.ExecuteNonQuery();
                        valor++;
                    }
                }
                t.Commit();
            }
            catch { if (t != null) { t.Rollback(); } n = 0; }
            finally { if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); } }
            return n;
        }

    }
}
