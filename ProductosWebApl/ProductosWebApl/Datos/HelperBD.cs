using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging.Abstractions;

namespace ProductosWebApl.Datos
{
    public class HelperBD
    {
        private static HelperBD instance;
        private SqlConnection cnn;

        private HelperBD()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static HelperBD Getinstancia()
        {
            if (instance == null)
            {
                instance = new HelperBD();
            }
            return instance;
        }

        public DataTable Select(string sp)
        {
            SqlTransaction t = null;
            DataTable dt = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable Select(string sp, List<Parametro> lst)
        {
            SqlTransaction t = null;
            DataTable dt = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
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

        public int Insertar(string sp, List<Parametro> lst, string parameterOutput)
        {
            SqlTransaction t = null;
            int n = 0;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                if (lst != null)
                {
                    foreach (Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }
                }
                if (!string.IsNullOrEmpty(parameterOutput) && !string.IsNullOrWhiteSpace(parameterOutput))
                {
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = parameterOutput;
                    p.DbType = DbType.Int32;
                    p.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    n = Convert.ToInt32(p.Value);
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
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }

            return n;
        }

        public int EjecutarSql(string sp, List<Parametro> lst)
        {
            SqlTransaction t = null;
            int n = 0;
            try
            {
            cnn.Open();
            t = cnn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(sp, cnn);//, t);
            cmd.CommandType = CommandType.StoredProcedure;

            if (lst != null)
            {
                foreach (Parametro x in lst)
                {
                    cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                }
            }

            n = cmd.ExecuteNonQuery();
            }
            catch
            {
            if (t != null) { t.Rollback(); }
            n = 0;
            }
            finally
            {
            if (cnn != null && cnn.State == ConnectionState.Open) { cnn.Close(); }
            }
            
            return n;
        }
    }
}
