using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class CajaAhorro : Cuenta
    {
        private double tasaInteres;

        public double TasaInteres
        {
            get { return tasaInteres; }
            set { tasaInteres = value; }
        }
        public CajaAhorro() : base()
        {
            this.tasaInteres = 0;
        }
        public CajaAhorro(int numero, double saldo, Cliente titular, double tasaInteres)
            : base(numero, saldo, titular)
        {
            this.tasaInteres = tasaInteres;
        }
        public override string ToString()
        {
            return "|Caja de Ahorro: " + base.ToString();
        }
        public override void Depositar(double importe)
        {
            Saldo += importe;
        }

        public override void Extraer(double importe)
        {
            if (importe <= Saldo)
                Saldo -= importe;
        }
    }
}
