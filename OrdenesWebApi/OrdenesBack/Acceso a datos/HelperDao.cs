using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesBack.Acceso_a_datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        SqlConnection cnn;

        private HelperDao()
        {
            cnn = new SqlConnection(@"Data Source=LAPTOP-FC0TODPF\SQLEXPRESS;Initial Catalog=db_ordenes;Integrated Security=True");

        }

        public static HelperDao getInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        public DataTable Select(string sp, List<Parametro> lst)
        {

            SqlTransaction t = null;
            DataTable dt;
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
            finally { if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close(); }

            return dt;
        }

        public int Insert(string sp, List<Parametro> lst, string pOutput)
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
                    foreach (Parametro x in lst)
                    {
                        cmd.Parameters.AddWithValue(x.Nombre, x.Valor);
                    }
                }
                if (!string.IsNullOrEmpty(pOutput) && !string.IsNullOrWhiteSpace(pOutput))
                {
                    SqlParameter p = new SqlParameter(pOutput, SqlDbType.Int);
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
            finally { if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close(); }
            return n;
        }
    }
}
