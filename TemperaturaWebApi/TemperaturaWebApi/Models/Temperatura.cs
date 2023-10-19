namespace TemperaturaWebApi.Models
{
    public class Temperatura
    {
        private int codIOT;
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
        public int CodIOT
        {
            get { return codIOT; }
            set { codIOT = value; }
        }

        public Temperatura()
        {

        }
        public Temperatura(int codIOT, DateTime fechaHora, double valor)
        {
            CodIOT = codIOT;
            FechaHora = fechaHora;
            Valor = valor;
        }
    }
}
