namespace PersonaProblemaSegundaClase
{

    class Program
    {
        internal static void Main()
        {
            // Creamos nuestros objetos
            //primer objeto, declarado e inicializado en el mismo paso (parámetros fijos)
            Persona personaUno = new Persona("Joaquin", "M", 18, 65, 1.70);

            //segundo objeto, declarado primero e inicializado después(parámetros fijos):
            Persona personaDos;//null
            personaDos = new Persona("Maria", "F", 21, 75, 1.58);

            //tercer objeto, constructor por defecto: uso de properties para settear
            //los valores mediante lectura por teclado:
            Persona personaTres = new Persona();
            Console.WriteLine("Ingrese el nombre: ");
            personaTres.pNombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Sexo [F:Feminino|M:Masculino]: ");
            personaTres.pSexo = Console.ReadLine();
            Console.WriteLine("Ingrese la edad: ");
            int edad = Int32.Parse(Console.ReadLine());
            personaTres.pEdad = edad;
            personaTres.pPeso = 45;
            personaTres.pAltura = 1.65;

            //string cad = "cadena " + 8; Si COMPILA
            //9 + "otracadena"; NO COMPILA

            //Uso de operador ternario ? para mostrar SI/NO en vez de true/false:
            Console.WriteLine( "El IMC de la persona 1 es: " + personaUno.CalcularIMC() + " ¿La persona es mayor?: " + (personaUno.EsMayorDeEdad()?"SI":"NO" ));
            Console.WriteLine("El IMC de la persona 2 es: " + personaDos.CalcularIMC() + " ¿La persona es mayor?: " + (personaDos.EsMayorDeEdad()?"SI": "NO"));
            Console.WriteLine("El IMC de la persona 3 es: " + personaTres.CalcularIMC() + " ¿La persona es mayor?: " + (personaTres.EsMayorDeEdad()?"SI":"NO"));
        }
    }
}