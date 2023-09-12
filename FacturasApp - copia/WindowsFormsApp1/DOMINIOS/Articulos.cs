using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Articulos
    {
        private int id;
        private string nombre;
        private double precio;
        private int cantidad;
        private bool activo;

        public int Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public bool Activo
        {
            get { return activo; }
            
        }

        public Articulos(int id, string nombre, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            activo = Activo;
        }
        public Articulos(int id, string nombre, double precio, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            activo = Activo;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
