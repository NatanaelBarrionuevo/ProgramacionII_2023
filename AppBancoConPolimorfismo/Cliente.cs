using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Cliente:Persona
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private double limite;

        public double Limite
        {
            get { return limite; }
            set { limite = value; }
        }
        public Cliente() :base()
        {
            limite = codigo = 0;
        }
        public Cliente(string nombre, int documento, bool sexo, int codigo, double limite)
               :base(nombre,documento,sexo)
        {
            this.codigo=codigo;
            this.limite = limite;
        }
        public override string ToString()
        {
            return "| Código: " + codigo + base.ToString() + " |Límite de Crédito: $" + limite;
        }
    }
}
