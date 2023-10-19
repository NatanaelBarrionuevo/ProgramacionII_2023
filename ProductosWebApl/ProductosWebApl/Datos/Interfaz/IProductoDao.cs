using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Models;

namespace ProductosWebApl.Datos.Interfaz
{
    public interface IProductoDao
    {
        int CargarProductos(Producto oProducto);
        List<Producto> ConsultarProductos();
        ProductoDTO ConsultarProductos(int id);
        int ActualizarProducto(Producto oProducto);
        int BajaProductos(int id);
    }
}
