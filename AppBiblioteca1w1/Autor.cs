using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w1
{
    internal class Autor :Persona // Herencia--> Autor es Persona
    {
        //Atributos
        private string alias;

        //Propiedades
        public string pAlias
        { get { return alias; } set { alias = value; } }

        //Constructores
        public Autor() :base()
        {
            this.alias = string.Empty;
        }
        public Autor(string alias,string nombre, int edad, string sexo,double peso, double altura)
               :base(nombre,edad,sexo,peso,altura)
        {
            this.alias = alias;
        }

        //Metodos()
        public override string ToString()   //Redefine un metodo de la clase Object
        {
            string aux = "";
            aux += "Alias: " + this.alias + base.ToString(); 
            return aux;
        }
        public override void cumpleanio()  //Redefine un metodo abstracto de la clase base
        {
            edad++;
        }
        public override bool esMayorDeEdad()  //Redefine un metodo virtual de la clase base
        {
            if (edad > 18)
                return true;
            else
                return false;
        }
    }
}
