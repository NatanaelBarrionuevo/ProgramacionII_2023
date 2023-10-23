namespace RecetaWebApi.Datos.DTOs
{
    public class RecetaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cheff { get; set; }

        public RecetaDTO(int id, string nombre, string cheff)
        {
            Id = id; 
            Nombre = nombre;
            Cheff = cheff;

        }
    }
}
