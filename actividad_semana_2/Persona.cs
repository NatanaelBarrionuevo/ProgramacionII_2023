using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaProblemaSegundaClase
{
    class Persona
    {
        // ATRIBUTOS
        private string nombre;
        private string sexo;
        private int edad;
        private double peso;
        private double altura;

        public Persona() //Constructor sin parametros
        {
            nombre = "S/N";
            altura = peso = edad = 0;
        }

        public Persona(string nombre, string sexo, int edad, double peso, double altura)
        // Constructor con parametros
        // (this.) Hace referencia al atributo de la clase
        {

            this.nombre = nombre;
            this.sexo = sexo;
            this.edad = edad;
            this.peso = peso;
            this.altura = altura;

        }

        //Propiedades para acceder a los atributos desde fuera
        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public string pSexo
        {
            set { sexo = value; }
            get { return nombre; }
        }

        //ESTO ES UNA FULL-PROPERTY
        public int pEdad
        {
            set
            {

                if (value >= 0) edad = value;
            }
            get { return edad; }
        }

        public double pPeso
        {
            set { peso = value; }
            get { return peso; }
        }

        public double pAltura
        {
            set { altura = value; }
            get { return altura; }
        }

        //Metodos propios
        public int CalcularIMC()
        {
            int imc = 1;
            
            double resultado = peso / (altura * altura);
            if (resultado >= 20 && resultado <= 25)
            {
                imc = 0;
            }
            if (resultado < 20)
            {
                imc = -1;
            }

            return imc;
        }

        public bool EsMayorDeEdad() //Este metodo al ser propio de la clase, se tiene acceso a edad
        {
            return edad >= 21;
        }


        /** Estos son métodos propios para acceder y/o modificar
         * los atributos de la clase, que previamente llamamos 
         * PROPERTIES:
        public int GetEdad()
        {
            return edad;
        }

        public void SetEdad(int e)
        {
            if (e > 0 && e < 150)
                edad = e;
        }**/
    }

}
