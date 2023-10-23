using RecetaWebApi.Datos.DTOs;
using RecetaWebApi.Datos.Interfaz;
using RecetaWebApi.Models;
using System.Data;

namespace RecetaWebApi.Datos.Implementaciones
{
    public class RecetaDao : IRecetaDao
    {

        public int Actualizar(Receta receta)
        {
            int n = -1;
            if (receta != null)
            {
                List<Parametro> lst = new List<Parametro>();
                n = HelperBD.GetInstancia().EjecutarSql("", lst);
            }
            
            return n;
        }

        public int Eliminar(int receta)
        {
            int n = -1;
            if (receta > 0)
            {
                List<Parametro> lst = new List<Parametro>();
                n = HelperBD.GetInstancia().EjecutarSql("", lst);
            }
            
            return n;
        }

        public List<IngredienteDTO> GetAllIngredientesDTO()
        {
            DataTable dt = HelperBD.GetInstancia().Select("", new List<Parametro>());
            List<IngredienteDTO> lst = new List<IngredienteDTO>();
            IngredienteDTO ingrediente;
            foreach (DataRow x in dt.Rows)
            {
                int id = Convert.ToInt32(x.ItemArray[0]);
                string nombre = x.ItemArray[1].ToString();
                double cantidad = Convert.ToDouble(x.ItemArray[2]);
                ingrediente = new IngredienteDTO(id, nombre, cantidad);
                lst.Add(ingrediente);
            }
            return lst;
        }

        public List<RecetaDTO> GetAllRecetasDTO()
        {
            DataTable dt = HelperBD.GetInstancia().Select("", new List<Parametro>());
            List<RecetaDTO> lst = new List<RecetaDTO>();
            RecetaDTO receta;
            foreach (DataRow x in dt.Rows)
            {
                int id = Convert.ToInt32(x.ItemArray[0]);
                string nombre = x.ItemArray[1].ToString();
                string cheff = x.ItemArray[2].ToString();
                receta = new RecetaDTO(id, nombre, cheff);
                lst.Add(receta);
            }
            return lst;
        }

        public List<Receta> GetRecetas()
        {
            throw new NotImplementedException();
        }

        public int Ingresar()
        {
            throw new NotImplementedException();
        }
    }
}
