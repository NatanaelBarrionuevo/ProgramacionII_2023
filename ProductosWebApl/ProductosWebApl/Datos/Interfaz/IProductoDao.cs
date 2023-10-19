using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Models;

namespace ProductosWebApl.Datos.Interfaz
{
    public interface IProductoDao
    {
        int IngProductos(ProductoDTO oProducto);
        List<Producto> LstProductos();
        ProductoDTO LstProductos(int id);
        int ActProducto(Producto oProducto);
        int BorrProductos(int id);
    }
}
