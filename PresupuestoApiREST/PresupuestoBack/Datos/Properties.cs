using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestosBack.Datos
{
    public class Properties
    {
        private static Properties instancia;
        private string cnnString;

        private Properties()
        {
           cnnString = @"Data Source=LAPTOP-FC0TODPF\\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
        }

        public string CnnString { get; }
        public static Properties GetIntancia()
        {
            if(instancia == null)
            {
                instancia = new Properties();
            }
            return instancia;
        }

        public override string ToString()
        {
            return CnnString;
        }
    }
}
