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
        public int ContadorCuentas(int tipoCuenta)
        {
            int contador = 0;
            for (int i = 0; i < ultima; i++)
            {
                if (cuentas[i].Tipo.Equals(tipoCuenta))
                    contador++;
            }
            return contador;
        }
    }
}
