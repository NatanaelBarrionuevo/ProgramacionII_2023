using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ABMLibros.Datos
{
    public class AccesoDatos
    {
        private string cadenaConexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            cadenaConexion = @"Data Source=172.16.10.196;Initial Catalog=TUPPI;User ID=alumno1w1;Password=alumno1w1";
            conexion = new SqlConnection(cadenaConexion);
        }

        private void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection= conexion;
            comando.CommandType = CommandType.Text;
        }
        private void Desconectar()
        {
            conexion.Close();
        }
        public DataTable ConsultarBD(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            comando.CommandText = consulta;
            dt.Load(comando.ExecuteReader());
            Desconectar();
            return dt;
        }
        public int ActualizarBD(string consulta,List<Parametro> lp)
        {
            int filasAfectadas = 0;
            Conectar();
            comando.CommandText = consulta;
            comando.Parameters.Clear();
            foreach (Parametro p in lp)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            filasAfectadas = comando.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }
    }
}
