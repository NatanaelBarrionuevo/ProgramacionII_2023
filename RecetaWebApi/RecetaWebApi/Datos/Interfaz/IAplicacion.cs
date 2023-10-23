using RecetaWebApi.Datos.DTOs;
using RecetaWebApi.Models;

namespace RecetaWebApi.Datos.Interfaz
{
    public interface IAplicacion
    {
        List<RecetaDTO> GetRecetas();
        List<IngredienteDTO> GetIngredientes();
        List<Receta> GetAllRecetas();
        int AgregarReceta();
        int ActualizarReceta(Receta oReceta);
        int EliminarReceta(int indice);
    }
}
