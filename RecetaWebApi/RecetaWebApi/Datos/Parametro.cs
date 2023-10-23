namespace RecetaWebApi.Datos
{
    public class Parametro
    {
		private string nombre;
		private object valor;

		public object Valor
		{
			get { return valor; }
			set { valor = value; }
		}


		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

        public Parametro(string nombre, object valor)
        {
			Nombre = nombre;
			Valor = valor;
        }
    }
}
