using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creamos un autor sin parametros y luego seteamos con propiedades
            Autor oAutor1 = new Autor();
            oAutor1.pNombre = "Cervantes";
            oAutor1.pEdad = 87;
            oAutor1.pPeso = 65;
            oAutor1.pAltura = 1.70;
            oAutor1.pSexo = "H";
            oAutor1.pAlias = "Pancho";

            //Creamos un libro sin parametros y luego seteamos con propiedades
            //algunos datos ingresamos por teclado, otros los asignamos directamente
            Libro oLibro1 =new Libro();
            
            Console.Write("Ingrese ISBN: ");
            oLibro1.pIsbn = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Título: ");
            oLibro1.pTitulo = Console.ReadLine();
            Console.Write("Ingrese Páginas: ");
            oLibro1.pPaginas = Convert.ToInt32(Console.ReadLine());

            //asociamos el Autor con el Libro ---> implica que primero debe crearse oAutor
            oLibro1.pAutor = oAutor1;
          
            Console.WriteLine(oLibro1.ToString());

            //Creamos un autor con parametros
            Autor oAutor2 = new Autor("Pepe","Gimemnez", 75, "H", 80, 1.60);

            //Creamos un libro con parametros
            Libro oLibro2 = new Libro(1234, "Platero y yo",oAutor2, 50);
            Console.WriteLine(oLibro2.ToString());

            //Cual es el titulo del libro mas grande? (cantidad de paginas)
            if (oLibro1.pPaginas > oLibro2.pPaginas)
                Console.WriteLine("El libro " + oLibro1.pTitulo + " tiene más páginas que el libro " + oLibro2.pTitulo);
            else
                Console.WriteLine("El libro " + oLibro2.pTitulo + " tiene más páginas que el libro " + oLibro1.pTitulo);

            //Cual es el titulo del libro que tiene el autor mas viejo? (mayor edad)
            if (oLibro1.pAutor.pEdad > oLibro2.pAutor.pEdad)
                Console.WriteLine("El libro " + oLibro1.pTitulo + " tiene el autor mas viejo...");
            else 
                Console.WriteLine("El libro " + oLibro2.pTitulo + " tiene el autor mas viejo...");

            // if (oAutor1.pEdad > oAutor2.pEdad) Está mal!!! no corresponde por el modelo Libro --> Autor

            //////Biblioteca//////
            
            Biblioteca miBiblioteca = new Biblioteca(2);
            miBiblioteca.agregarLibro(oLibro1);
            miBiblioteca.agregarLibro(oLibro2);
            Console.WriteLine("Mi Biblioteca\n"+miBiblioteca.mostrarListado());

            //Cual es el titulo del libro mas grande de la Biblioteca? (cantidad de paginas)
            Console.WriteLine("El libro más grande de mi Bibloteca es: "+miBiblioteca.mayorCantidadPaginas().pTitulo);

            Console.Read();
        }
    }
}
