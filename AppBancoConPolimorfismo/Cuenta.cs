using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal abstract class Cuenta
    {
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        //private int tipo;   //1-Caja Ahorro 2-Cuenta Corriente

        //public int Tipo
        //{
        //    get { return tipo; }
        //    set { tipo = value; }
        //}
        private double saldo;

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        private Cliente titular;

        public Cliente Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public Cuenta()
        {
            this.saldo = this.numero = 0;
            this.titular = null;
        }
        public Cuenta(int numero, double saldo, Cliente titular)
        {
            this.numero = numero;
            //this.tipo = tipo;
            this.saldo = saldo;
            this.titular = titular;
        }
        public override string ToString()
        {
            return " |Numero: " + numero + " |Saldo: $" + saldo + titular.ToString();
        }
        //public string TipoToString()
        //{
        //    string aux = "";
        //    switch (tipo)
        //    {
        //        case 1: { aux = "Caja de Ahorro"; break; }
        //        case 2: { aux = "Cuenta Corriente"; break; }
        //        default:{aux = "Cuenta Desconocida"; break; }
        //    }
        //    return aux;
        //}

        public abstract void Depositar(double importe);

        public abstract void Extraer(double importe);
    }
}
