namespace RecetaWebApi.Models
{
    public class Receta 
    {
		private int id;
		private string nombre;
		private string cheff;
		List<Ingrediente> ingredientes;

		public List<Ingrediente> Ingredientes
		{
			get { return ingredientes; }
			set { ingredientes = value;}
		}
		public string Cheff
		{
			get { return cheff; }
			set { cheff = value; }
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

        public Receta()
        {
				
        }

		public void AgregarIngrediente(Ingrediente x)
		{
			ingredientes.Add(x);
		}

		public void QuitarIngrediente(int indice)
		{
			ingredientes.RemoveAt(indice);
		}
    }
}
