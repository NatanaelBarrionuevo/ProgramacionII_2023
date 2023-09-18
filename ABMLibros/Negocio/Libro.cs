using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMLibros.Negocio
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int Autor { get; set; }
        public int Formato { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public double Precio { get; set; }

        public Libro()
        {
            Precio = Formato = Autor = IdLibro = 0;
            Titulo = "";
            FechaPublicacion = DateTime.Today;
        }
        public Libro(int idLibro, string titulo, int autor, int formato, DateTime fechaPublicacion, double precio)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Autor = autor;
            Formato = formato;
            FechaPublicacion = fechaPublicacion;
            Precio = precio;
        }
        public override string ToString()
        {
            return IdLibro+" - "+Titulo+" - "+Precio;
        }

    }
}
