namespace RecetaWebApi.Models
{
    public class Ingrediente
    {
		private int id;
		private string nombre;
		private double cantidad;
		private int idReceta;

		public int IdReceta
		{
			get { return idReceta; }
			set { idReceta = value; }
		}

		public double Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}


		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

        public Ingrediente()
        {
			
        }
    }
}
