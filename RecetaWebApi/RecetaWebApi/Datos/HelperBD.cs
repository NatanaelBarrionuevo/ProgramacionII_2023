using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace RecetaWebApi.Datos
{
    public class HelperBD
    {
        private static HelperBD instancia;
        private SqlConnection cnn;
        private HelperBD()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static HelperBD GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperBD();
            }
            return instancia;
        }

        public DataTable Select(string sp, List<Parametro> lst)
        {
            DataTable dt;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
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

        public int InsertarSql(string sp, List<Parametro> lst, string pOutput)
        {
            SqlTransaction t = null;
            int n;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                if (!string.IsNullOrEmpty(pOutput) && !string.IsNullOrWhiteSpace(pOutput))
                {
                    SqlParameter parametro = new SqlParameter(pOutput, SqlDbType.Int);
                    parametro.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parametro);
                    cmd.ExecuteNonQuery();
                    n = Convert.ToInt32(parametro.Value);
                }
                else
                {
                    n = cmd.ExecuteNonQuery();
                }
                t.Commit();

            }
            catch
            {
                if (t != null) { t.Rollback(); }
                n = 0;
            }
            finally { if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); } }
            return n;
        }

        public int EjecutarSql(string sp, List<Parametro> lst)
        {
            int n;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parametro p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                n = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch { if (t != null) { t.Rollback(); } n = 0; }
            finally { if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); } }
            return n;
        }
    }
}