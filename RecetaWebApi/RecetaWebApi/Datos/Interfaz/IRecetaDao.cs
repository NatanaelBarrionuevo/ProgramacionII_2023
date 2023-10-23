using RecetaWebApi.Datos.DTOs;
using RecetaWebApi.Models;

namespace RecetaWebApi.Datos.Interfaz
{
    public interface IRecetaDao
    {
        List<RecetaDTO> GetAllRecetasDTO();
        List<IngredienteDTO> GetAllIngredientesDTO();
        List<Receta> GetRecetas();
        int Ingresar();
        int Actualizar(Receta oReceta);
        int Eliminar(int indice);
    }
}
