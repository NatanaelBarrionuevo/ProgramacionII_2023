using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpinteriaApp_1w3.Entidades;

namespace CarpinteriaApp_1w3.Datos
{
    internal class DBHelper
    {
        private SqlConnection conexion;
        
        public DBHelper() 
        {
            conexion = new SqlConnection(@"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023_114094;User ID=alumno1w1; Password=alumno1w1");
        }


        public int ProximoPresupuesto()
        {
            conexion.Open();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_PROXIMO_ID";
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@next";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(parameter);
            cmd.ExecuteNonQuery();

            conexion.Close();
            
            return (int)parameter.Value;

        }

        public DataTable Consultar(string nombreSP)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023_114094;User ID=alumno1w1; Password=alumno1w1";
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;

        
        }

        public DataTable Consultar(string nombreSP,List<Parametros> lstParametros)
        {

            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            foreach (Parametros p in lstParametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.valor);

            }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conexion.Close();
            return dt;


        }

        public bool ConfirmarPresupuesto(Presupuesto oPresupuesto)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try 
            {
                conexion.Open();

                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.Transaction = t;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                
                cmd.Parameters.AddWithValue("cliente", oPresupuesto.Cliente);
                cmd.Parameters.AddWithValue("dto", oPresupuesto.Descuento);
                cmd.Parameters.AddWithValue("total", oPresupuesto.CalcularTotal());

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@presupeusto_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();

                int presupuestoNro = (int)parametro.Value;
                int detalle = 1;

                SqlCommand cmdDetalle;
                
                foreach (DetallePresupuesto dp in oPresupuesto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion,t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    
                    cmdDetalle.Parameters.AddWithValue("presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("detalle", detalle);
                    cmdDetalle.Parameters.AddWithValue("id_producto", dp.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery(); 
                    detalle++;
                
                }
            }
            catch 
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
    }
}
