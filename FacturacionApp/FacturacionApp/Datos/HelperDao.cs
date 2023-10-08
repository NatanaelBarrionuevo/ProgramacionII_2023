using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace FacturacionApp.Datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection cnn;

        private HelperDao()
        {
            cnn = new SqlConnection("");
        }
        
        public static HelperDao GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public DataTable ConsultarSql(string nombreSP, List<Parametro> lst)
        {
            SqlTransaction t = null;
            DataTable dt = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(nombreSP, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null) { t.Rollback(); }
                dt = null;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }
            return dt;
        }

        public int InsertarSql(string nombreSP, List<Parametro> lst)
        {
            SqlTransaction t = null;
            int ok = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(nombreSP, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }
                }
                ok = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null) { t.Rollback(); }
                ok = 0;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }
            return ok;
        }
        public int InsertarSql(string nombreSP, List<Parametro> lst, string paramOut)
        {
            SqlTransaction t = null;
            int ok = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(nombreSP, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }
                }
                SqlParameter p = new SqlParameter(paramOut, SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                ok = Convert.ToInt32(p.Value);
                t.Commit();
            }
            catch
            {
                if (t != null) { t.Rollback(); }
                ok = 0;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }
            return ok;
        }

        public int EjecutarSql(string nombreSP, List<Parametro> lst)
        {
            SqlTransaction t = null;
            int ok = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(nombreSP, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if(lst != null)
                {
                    foreach(Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }                   
                }
                ok = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch { if(t!= null) { t.Rollback(); } ok = 0; }
            finally { if(cnn!= null && cnn.State == ConnectionState.Open) {  cnn.Close(); } }
            return ok;
        }
    }
}
