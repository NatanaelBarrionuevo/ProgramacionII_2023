using Microsoft.AspNetCore.Mvc;
using RecetaWebApi.Datos.DTOs;
using RecetaWebApi.Datos.Interfaz;
using RecetaWebApi.Models;

namespace RecetaWebApi.Datos.Implementaciones
{
    public class Aplicacion : IAplicacion
    {
        private IRecetaDao dao;
        private static readonly List<Receta> recetas = new List<Receta>();

        public static List<Receta> Recetas
        {
            get { return recetas; }
        }
        public Aplicacion()
        {
            dao = new RecetaDao();
        }
        public List<RecetaDTO> GetRecetas()
        {
            return dao.GetAllRecetasDTO();
        }

        public List<IngredienteDTO> GetIngredientes()
        {
            return dao.GetAllIngredientesDTO();
        }

        public List<Receta> GetAllRecetas()
        {
            
            return dao.GetRecetas();
        }

        public int AgregarReceta()
        {
            return dao.Ingresar();
        }

        public int ActualizarReceta(Receta oReceta)
        {
            int n = dao.Actualizar(oReceta);
            if ( n == 1)
            {
                foreach(Receta x in recetas)
                {
                    if (oReceta.Id.Equals(x.Id))
                    {
                        x.Nombre = oReceta.Nombre;
                        x.Cheff = oReceta.Cheff;
                        x.Ingredientes.Clear();
                        x.Ingredientes = oReceta.Ingredientes;
                        
                    }
                }
            }
            return n;
        }

        public int EliminarReceta(int indice)
        {
            int n = dao.Eliminar(indice);
            if ( n == 1)
            {
                recetas.RemoveAt(indice);
            }
            return n;
        }


    }
}
