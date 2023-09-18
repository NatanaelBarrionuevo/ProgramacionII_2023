using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    public class Password
    {
		private int longitud;
		private string valor;

        public Password()
        {
            longitud = 8;//valor x defecto
            valor = GenerarPassword();
        }

        public Password(int l)
        {
            longitud = l;
            valor = GenerarPassword();
        }


        //Este método es privado porque no será accesible
        //desde fuera de la clase. Es decir, no es posible
        //pedirle a un objeto Password que genere su valor.
        //Dicho valor se asigna cuando se crea el objeto.

        private string GenerarPassword()
        {
            string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0987654321";//62 caracteres posibles
            string pass = "";
            //Difinimos un ciclo que realiza tanta iteraciones
            //como longitud tenga el password a generar:
            //int i;
            Random rand;
            for (int i = 0; i < longitud; i++)
            {
               //generamos un valor aleatorio entre [0:61] para tomar un letra al azar:
                rand = new Random();
                int pos = rand.Next(letras.Length); //<62
                //concatenamos la letra de la posición pos a la cadena 'pass':
                pass += letras[pos];
            }
            return pass;
        }

        public int Longitud
		{
			get { return longitud; }
			set { 
                if(value >= 8)//nunca un pass con longitud menor a 8
                {
                    longitud = value;
                    valor = GenerarPassword();
                }
             }
		}
        public string Valor
        {
            //propiedad de solo lectura
            get { return valor; }
        }

        //Método propio: esFuerte()
        //Permite indicar si el password tiene un valor
        //fuerte según lo que se indica por enunciado
        public bool EsFuerte()
        {
            //declaramos 3 contadores
            int cMayusculas, cMinusculas, cNumeros;
            //Inicializamos todos los contadores mediante 
            //asignación múltiple:
            cMayusculas = cMinusculas = cNumeros = 0;

            /*Recorremos la cadena y validamos letra por letra
            según su código ascii (sistema de representación numérica
            de letras, números y caracteres especiales).*/

            for (int i = 0; i < longitud; i++)
            {
              
                
                //valor[i] permite obtener cada letra del valor del objeto Password
                //si ese caracter lo asignamos dentro de una variable int
                //C# asigna automáticamente su valor ascii en la variable entera.
                int ascii = valor[i];// int ascii = 'J'

                //Tener en cuenta que:
                //Ascii entre 65 y 90 son letras mayúsculas
                //Ascii entre 97 y 122 son letras minúsculas
                //Ascii entre 48 y 57 son números
                //int x = 'a';//97
                if (ascii >= 65 && ascii <= 90)
                    cMayusculas++;
                if (ascii >= 97 && ascii <= 127)
                    cMinusculas++;
                if (ascii >= 48 && ascii <= 57)
                    cNumeros++;


                /* Otra alternativa para validar números:
                 * if (Char.IsDigit(valor[i]))
                    cNumeros++;
                */
            }
            //retornamos la comparación de los contadores
            return cMayusculas > 2 && cMinusculas > 1 && cNumeros > 5;
        }

    }
}
