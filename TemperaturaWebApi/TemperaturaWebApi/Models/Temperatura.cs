namespace TemperaturaWebApi.Models
{
    public class Temperatura
    {
        private int id;
        private int iot;
        private DateTime fechaHora;
        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public int Iot
        {
            get { return iot; }
            set { iot = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Temperatura()
        {
                
        }
        public Temperatura(int id, int iot, DateTime fechaHora, double valor)
        {
            Id = id;
            Iot = iot;
            FechaHora = fechaHora;
            Valor = valor;
        }
    }
}
