using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Banco
    {
        private string nombre;
        private Cuenta[] cuentas;
        private int ultima;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Banco()
        {
            nombre = string.Empty;
            ultima = 0;
            cuentas = new Cuenta[10];
        }
        public Banco(int tamanio)
        {
            nombre = string.Empty;
            ultima = 0;
            cuentas = new Cuenta[tamanio];
        }

        public bool AgregarCuenta(Cuenta cuenta)
        {
            if (ultima < cuentas.Length)
            {
                cuentas[ultima] = cuenta;
                ultima++;
                return true;
            }
            return false; // se completó el arreglo
        }
        public string ListarCuentas()
        {
            string aux = "Listado de Cuentas del banco " + nombre + "\n";
            //for (int i = 0; i < ultima; i++)
            //{
            //    aux += cuentas[i].ToString() + "\n";
            //}
            foreach (Cuenta cta in cuentas)
            {
                if (cta != null)
                    aux += cta.ToString() + "\n";
            }
            return aux;
        }
        public int ContadorCCAA()
        {
            int contador = 0;
            for (int i = 0; i < ultima; i++)
            {
                if (cuentas[i] is CajaAhorro)
                    contador++;
            }
            return contador;
        }
        // Generalizado para CCAA y CtaCte
        public int ContadorCuentas(Cuenta tipoCuenta)
        {
            int contador = 0;
            for (int i = 0; i < ultima; i++)
            {
                if (cuentas[i].GetType() == tipoCuenta.GetType())
                    contador++;
            }
            return contador;
        }
        //Saldo promedio de todas las cuentas
        public double SaldoPromedio()
        {
            double promedio = 0;
            for (int i = 0; i < ultima; i++)
            {
                promedio += cuentas[i].Saldo;
            }
            return promedio / ultima;
        }
        //Porcentaje de cuentas con titulares femeninos
        public double PorcetajeFemenino()
        {
            double chicas = 0;
            //for (int i = 0; i < ultima; i++)
            //{
            //    if (!cuentas[i].Titular.Sexo)
            //        chicas++;
            //}
            foreach (Cuenta cta in cuentas)
            {
                if (cta != null && !cta.Titular.Sexo) //--> cta.Titular.Sexo==false
                    chicas++;
            }
            return chicas / ultima * 100;
        }
        //Mayor limite de credito
        public Cuenta MayorLimite()
        {
            Cuenta mayor = null;
            foreach (Cuenta cta in cuentas)
            {
                if (mayor == null && cta != null) // primera vez
                    mayor = cta;
                else
                if (cta != null && cta.Titular.Limite > mayor.Titular.Limite)
                    mayor = cta;
            }
            return mayor;
        }

    }
}
