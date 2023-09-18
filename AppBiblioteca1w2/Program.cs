using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBiblioteca1w2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Revista revista1, revista2;
            Autor autor1, autor2;
            Libro libro1,libro2;

            revista1 = new Revista("Caras", 50, 123);
            revista2 = new Revista("Gente", 70, 678);

            autor1=new Autor();
            autor1.pNombre = "Gomez";
            autor1.pEdad = 45;
            autor1.pSexo = "H";
            autor1.pAltura = 1.80;
            autor1.pPeso = 80;
            autor1.pAlias = "Pepe";

            libro1=new Libro();

            Console.Write("Ingrese el ISBN: ");
            libro1.pIsbn = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el Título: ");
            libro1.pTitulo=Console.ReadLine();
            //Console.Write("Ingrese el Autor: ");
            libro1.pAutor = autor1;             //relacion de asociacion 1 a 1
            Console.Write("Ingrese las páginas: ");
            libro1.pPaginas=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(libro1.ToString());

            autor2 = new Autor("Paco","Perez", 65, "M", 70, 1.70);
            libro2 = new Libro(1234, "Harry", autor2, 248);

            Console.WriteLine(libro2.ToString());

            if (libro1.pPaginas > libro2.pPaginas)
                Console.WriteLine("Libro " + libro1.pTitulo + " tiene mas páginas que libro " + libro2.pTitulo);
            else
                Console.WriteLine("Libro " + libro2.pTitulo + " tiene mas páginas que libro " + libro1.pTitulo);

            //Libro con autor mas alto

            //if (autor1.pAltura>autor2.pAltura)  Está MAL!!!!

            if (libro1.pAutor.pAltura > libro2.pAutor.pAltura)
                Console.WriteLine("El libro con autor mas alto es: "+libro1.pTitulo);
            else
                Console.WriteLine("El libro con autor mas alto es: "+libro2.pTitulo);

            /////////////// Biblioteca /////////////

            Biblioteca miBiblioteca = new Biblioteca();
            miBiblioteca.agregarPublicacion(libro1);
            miBiblioteca.agregarPublicacion(libro2);
            miBiblioteca.agregarPublicacion(libro1);
            miBiblioteca.agregarPublicacion(libro2);
            miBiblioteca.agregarPublicacion(revista1);
            miBiblioteca.agregarPublicacion(revista2);
            Console.WriteLine(miBiblioteca.mostrarListado());

            Console.WriteLine(miBiblioteca.buscarPublicacion(Console.ReadLine()));

            Console.WriteLine("Cantidad de Libros: " + miBiblioteca.contarLibros(10));

            Console.Read();
        }
    }
}
