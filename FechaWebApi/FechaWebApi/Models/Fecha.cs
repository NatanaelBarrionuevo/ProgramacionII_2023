namespace FechaWebApi.Models
{
    public class Fecha
    {
		private int numero;
		private string dia;
		private int mes;
		private int anio;

		public int Anio
		{
			get { return anio; }
			set { anio = value; }
		}


		public int Mes
		{
			get { return mes; }
			set { mes = value; }
		}


		public string Dia
		{
			get { return dia; }
			set { dia = value; }
		}

		public int Numero
		{
			get { return numero; }
			set { numero = value; }
		}

		public Fecha()
		{
			DateTime fechaActual = DateTime.Today;
			Numero = fechaActual.Day;
			Dia = fechaActual.DayOfWeek.ToString();
			Mes = fechaActual.Month;
			Anio = fechaActual.Year;
		}
	}
}
