using ProductosWebApl.Datos.DTOs;
using ProductosWebApl.Datos.Interfaz;
using ProductosWebApl.Models;
using System.Data;

namespace ProductosWebApl.Datos.Implementaciones
{
    public class ProductoDao : IProductoDao
    {


        public ProductoDao()
        {

        }
        public int ActProducto(Producto oProducto)
        {
            List<Parametro> lst = new List<Parametro>()
            {
                new Parametro("@cod", oProducto.Codigo),
                new Parametro("@nom", oProducto.Precio),
                new Parametro("@pre", oProducto.Precio)
            };
            int x = HelperBD.Getinstancia().EjecutarSql("sp_actualizar_producto", lst);
            return x;
        }

        public int BorrProductos(int id)
        {
            List<Parametro> lst = new List<Parametro>()
            {
               new Parametro("@cod", id)
            };
            int x = HelperBD.Getinstancia().EjecutarSql("sp_actualizar_producto", lst);
            return x;
        }
        public int IngProductos(ProductoDTO oProducto)
        {
            List<Parametro> lst = new List<Parametro>()
            {                
                new Parametro("@nom", oProducto.Nombre),
                new Parametro("@pre", oProducto.Precio)
            };
            int x = HelperBD.Getinstancia().Insertar("sp_insertar_producto", lst, "@cod");
            return x;
        }

        public List<Producto> LstProductos()
        {
            DataTable tabla = HelperBD.Getinstancia().Select("sp_consultar_productos");
            List<Producto> lst = new List<Producto>();
            foreach (DataRow fila in tabla.Rows)
            {
                int codigo = Convert.ToInt32(fila.ItemArray[0]);
                string nombre = fila.ItemArray[1].ToString();
                double precio = Convert.ToDouble(fila.ItemArray[2]);
                lst.Add(new Producto(codigo, nombre, precio));

            }
            return lst;
        }

        public ProductoDTO LstProductos(int id)
        {
            List<Parametro> lst = new List<Parametro>() { new Parametro("@cod", id) };
            DataTable tabla = HelperBD.Getinstancia().Select("sp_consultar_producto", lst);
            ProductoDTO x = null;
            foreach (DataRow fila in tabla.Rows)
            {
                x = new ProductoDTO(fila.ItemArray[1].ToString(), Convert.ToDouble( fila.ItemArray[1]));
            }
            return x;
        }


    }
}
