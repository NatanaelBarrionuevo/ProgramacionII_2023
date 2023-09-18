using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Autor :Persona
    {
        //Atributos
        private string alias;

        //Constructores
        public Autor() :base()
        {
            this.alias = string.Empty;
        }
        public Autor(string alias, string nombre, int edad, string sexo, double peso, double altura)
               :base(nombre, edad, sexo, peso, altura)
        {
            this.alias = alias;
        }

        //Propiedades
        public string pAlias
        { get { return alias; } set { alias = value; } }

        //Metodos()
        public override string ToString()
        {
            return "Alias: " + alias + " |" + base.ToString();
        }
        public override void cumpleanio(int x)
        {
            edad=x;
        }
        public override bool esMayorDeEdad()
        {
            if (edad > 18)
                return true;
            else
                return false;
        }
    }
}
