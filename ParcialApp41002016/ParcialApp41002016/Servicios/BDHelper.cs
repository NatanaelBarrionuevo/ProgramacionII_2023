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

namespace ParcialApp41002016.Servicios
{
    public class BDHelper
    {
        private SqlConnection conexion;
        private SqlCommand cmd;
        private string stringcnn = @"Data Source=DESKTOP-DECHDJG\SQLEXPRESS;Initial Catalog = carpinteria_db; Integrated Security = True";

        public string Stringcnn { set { stringcnn = value; }}
        public BDHelper()
        {
            conexion = new SqlConnection(stringcnn);

        }

        public int ObtenerId(string SP)
        {
            conexion.Open();
            cmd = new SqlCommand(SP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@next", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
          
            return (int)param.Value;
        }
        public DataTable ConsultarTabla(string SP)
        {
            conexion.Open();
            cmd = new SqlCommand(SP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable ConsultarTabla(string SP, List<Parametros> parametro)
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

        public bool AgregarPresupuesto(string SP_P, Presupuesto oP, string SP_D)
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
                cmd.Parameters.AddWithValue("@cto", oP.Descuento);
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
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nr", cod_presupuesto);
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
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return x;
        }
        public int BajaPresupuesto(int presupuesto_nro)
        {
            conexion.Open();
            cmd = new SqlCommand("SP_ELIMINAR_PRESUPUESTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@presupuesto_nro", presupuesto_nro);
            int resultado = cmd.ExecuteNonQuery();
            conexion.Close();
            return resultado;


        }
    }
}
