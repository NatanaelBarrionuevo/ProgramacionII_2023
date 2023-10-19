using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Datos.Interfaz;
using ProductosWebApl.Models;

namespace ProductosWebApl.Datos.Implementaciones
{
    public class Servicio : IServicio
    {
        private IProductoDao dao;

        public Servicio()
        {
             dao = new ProductoDao();
        }

        public int ActualizarProducto(Producto producto)
        {
            return dao.ActProducto(producto);
        }

        public int AgregarProducto(ProductoDTO producto)
        {
            return dao.IngProductos(producto);
        }

        public int EliminarProducto(int cod)
        {
            return dao.BorrProductos(cod);
        }

        public List<Producto> GetProductos()
        {
            return dao.LstProductos();
        }

        public ProductoDTO GetProductos(int cod)
        {
            return dao.LstProductos(cod);
        }
    }
}
