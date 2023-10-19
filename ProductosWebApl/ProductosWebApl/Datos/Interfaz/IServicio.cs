using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Models;

namespace ProductosWebApl.Datos.Interfaz
{
    public interface IServicio
    {
        List<Producto> GetProductos();
        ProductoDTO GetProductos(int cod);
        int AgregarProducto(ProductoDTO producto);
        int ActualizarProducto(Producto producto);
        int EliminarProducto(int cod);
    }
}
