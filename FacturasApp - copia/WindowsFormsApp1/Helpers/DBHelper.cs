using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace WindowsFormsApp1.Helpers
{
    public class DBHelper
    {
        // private Parametro parametro;
        private SqlConnection cnn;
        private string stringcnn = @"Data Source=DESKTOP-DECHDJG\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
        private SqlCommand cmd;
        private SqlTransaction t;

        public DBHelper()
        {
            cnn = new SqlConnection(stringcnn);
        }
        public int CargarNro()
        {

            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_NRO_FACTURA";

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@NEXT";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parametro);
            //int nro_factura = cmd.ExecuteNonQuery(); DEVUELVO EL VALOR DEL PARAMETRO, NO EL DE LA CONSULTA
            cmd.ExecuteNonQuery();
            cnn.Close();
            return (int)parametro.Value;

        }
        public DataTable Consultar(string SP)
        {


            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SP;

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;


        }
        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros)
        {

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            foreach (Parametro p in lstParametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);

            }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;


        }

        public bool ConfirmarFactura(Facturas oFactura)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                //Iniciamos la trasaccion.
                t = cnn.BeginTransaction();

            //Comando "Insertar_MAESTRO"
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";

                //Parametros INPUTS
                cmd.Parameters.AddWithValue("cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("dto", oFactura.Descuento);
                cmd.Parameters.AddWithValue("total", oFactura.CalcularTotal());

                //Parametro OUTPUT
                SqlParameter p = new SqlParameter();
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                p.ParameterName = "@act";
                cmd.Parameters.Add(p);

                //Ejecucion
                cmd.ExecuteNonQuery();
                int nroFactura = (int)p.Value;

                //Comando "Insertar_DETALLE"
                int nroDetalle = 1;
                foreach(detalleFacturas df in oFactura.Detalle)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("nroFactura", nroFactura);
                    cmdDetalle.Parameters.AddWithValue("nroDetalle", nroDetalle);
                    cmdDetalle.Parameters.AddWithValue("id_prod", df.Articulo.Id);
                    cmdDetalle.Parameters.AddWithValue("prod", df.Articulo.Nombre);
                    cmdDetalle.Parameters.AddWithValue("cantidad", df.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    nroDetalle++;
                }
                
                
            } catch 
            {
                if(t.Connection != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return resultado;
        }
    }
}
