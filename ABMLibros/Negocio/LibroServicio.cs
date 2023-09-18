using ABMLibros.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMLibros.Negocio
{
    public class LibroServicio
    {
        private AccesoDatos oDatos;

        public LibroServicio()
        {
            oDatos= new AccesoDatos();
        }

        public DataTable TraerAutores()
        {
            return oDatos.ConsultarBD("SELECT * FROM Autores");
        }

        public List<Libro> TraerLibros()
        {
            //mapeo
            List<Libro> list = new List<Libro>();
            DataTable dt = oDatos.ConsultarBD("SELECT * FROM Libros");
            foreach (DataRow fila in dt.Rows)
            {
                Libro l = new Libro();
                l.IdLibro = Convert.ToInt32(fila["idLibro"]);
                l.Titulo = fila["titulo"].ToString();
                l.Autor = Convert.ToInt32(fila["autor"]);
                l.Formato= Convert.ToInt32(fila["formato"]);
                l.FechaPublicacion = Convert.ToDateTime(fila["fechaPublicacion"]);
                l.Precio = Convert.ToDouble(fila["precio"]);
                list.Add(l);
            }
            return list;
        }

        public int Modificar(Libro l)
        {
            string consulta = "UPDATE Libros SET titulo=@titulo,"
                                              + "autor=@autor,"
                                              + "formato=@formato,"
                                              + "fechaPublicacion=@fechaPublicacion,"
                                              + "precio=@precio "
                                              + "WHERE idLibro=@idlibro";
            
            List<Parametro> lstParam = new List<Parametro>();
            lstParam.Add(new Parametro("@titulo", l.Titulo));
            lstParam.Add(new Parametro("@autor", l.Autor));
            lstParam.Add(new Parametro("@formato", l.Formato));
            lstParam.Add(new Parametro("@fechaPublicacion", l.FechaPublicacion));
            lstParam.Add(new Parametro("@precio", l.Precio));
            lstParam.Add(new Parametro("@idLibro", l.IdLibro));

            return oDatos.ActualizarBD(consulta, lstParam);
        }
    }
}
