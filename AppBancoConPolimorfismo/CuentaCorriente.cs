using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class CuentaCorriente : Cuenta
    {
        private double descubierto;

        public double Descubierto
        {
            get { return descubierto; }
            set { descubierto = value; }
        }
        public CuentaCorriente() : base()
        {
            this.descubierto = 0;
        }
        public CuentaCorriente(int numero, double saldo, Cliente titular,double descubierto) 
            : base(numero,saldo,titular)
        {
            this.descubierto = descubierto;
        }
        public override string ToString()
        {
            return "|Cuenta Corriente: " + base.ToString();
        }
        public override void Depositar(double importe)
        {
            Saldo += importe;
        }

        public override void Extraer(double importe)
        {
            if (importe <= (Saldo + descubierto))
                Saldo -= importe;
        }
    }
}
