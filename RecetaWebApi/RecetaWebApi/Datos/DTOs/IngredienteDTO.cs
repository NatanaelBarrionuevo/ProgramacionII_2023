namespace RecetaWebApi.Datos.DTOs
{
    public class IngredienteDTO
    {
        public int Id { get; set; }
        public double Cantidad { get; set; }
        public string Nombre { get; set; }

        public IngredienteDTO(int id, string nombre, double cantidad)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
        }
    }
}
