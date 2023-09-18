namespace CartasApp
{
    public class Program
    {
        public static void Main()
        {
            //Carta c = new Carta(); Solo se pueden instanciar tipos espécificos de cartas, 
            //que es lo que existe en el dominio real del problema.
            //Mazo ordenado por palo:
            Baraja oBaraja = new Baraja();
            Console.WriteLine(oBaraja.MostrarMazo());
            //Mezclar mazo:
            oBaraja.Barajar();
            Console.WriteLine(oBaraja.MostrarMazo());
            //Sumar todo los valores de las cartas:
            Console.WriteLine("Valor de todas las cartas del juego: " + oBaraja.ValorMazo());

        }
    }
}