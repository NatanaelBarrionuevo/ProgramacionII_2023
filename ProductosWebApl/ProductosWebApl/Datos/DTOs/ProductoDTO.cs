namespace ProductosWebApl.Datos.DTOs
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public ProductoDTO(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
