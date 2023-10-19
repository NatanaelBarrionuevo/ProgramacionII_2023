using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Datos.Interfaz;
using ProductosWebApl.Models;

namespace ProductosWebApl.Datos.Implementaciones
{
    public class ProductoDao : IProductoDao
    {
        private List<Producto> lst;

        public ProductoDao()
        {
            lst = new List<Producto>();
        }
        public int ActualizarProducto(Producto oProducto)
        {
            foreach (Producto p in lst)
            {
                if (oProducto.Codigo.Equals(p.Codigo))
                {
                    p.Nombre = oProducto.Nombre;
                    p.Precio = p.Precio;
                    return 1;
                }
            }
            return 0;
        }

        public int BajaProductos(int id)
        {
            foreach (Producto p in lst)
            {
                if (p.Codigo.Equals(id))
                {
                    lst.Remove(p);
                    return 1;
                }
            }
            return 0;
        }

        public int CargarProductos(Producto oProducto)
        {
            lst.Add(oProducto);
            return 1;
        }

        public List<Producto> ConsultarProductos()
        {
            return lst;
        }

        public ProductoDTO ConsultarProductos(int id)
        {
            ProductoDTO x = null;
            foreach (Producto p in lst)
            {
                if (p.Codigo.Equals(id))
                {
                    x = new ProductoDTO(p.Nombre, p.Precio);
                }
            }
            return x;
        }
    }
}
