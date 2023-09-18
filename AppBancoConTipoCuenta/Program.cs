using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente c1 = new Cliente("Pedro", 40000000, true, 123, 100000);
            Cliente c2 = new Cliente("Ana", 35000000, false, 456, 200000);

            Cuenta cta1 = new Cuenta();
            cta1.Numero = 98765432;
            cta1.Titular = c1;
            cta1.Saldo = 50000;
            cta1.Tipo = 1;

            Cuenta cta2 = new Cuenta(123451243, 2, 80000, c2);

            Banco miBanco=new Banco();
            miBanco.Nombre = "Macro";
            miBanco.AgregarCuenta(cta1);
            miBanco.AgregarCuenta(cta2);
            miBanco.AgregarCuenta(cta1);
            miBanco.AgregarCuenta(cta2);
            miBanco.AgregarCuenta(cta1);
            miBanco.AgregarCuenta(cta2);
            miBanco.AgregarCuenta(cta1);
            miBanco.AgregarCuenta(cta1);

            Console.WriteLine(miBanco.ListarCuentas());

            Console.WriteLine("Cajas de Ahorro: " + miBanco.ContadorCuentas(1));
            Console.WriteLine("Cuentas Corrientes: " + miBanco.ContadorCuentas(2));

            Console.Read();
        }
    }
}
