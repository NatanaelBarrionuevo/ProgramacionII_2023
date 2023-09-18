namespace PasswordApp
{
    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Ingrese un email: ");
            string email = Console.ReadLine();

            Usuario uPrueba = new Usuario(email); //usuario de membresia

            Password oPassword = null;

            Console.WriteLine("Ingrese el largo del password: ");
            int tamanio = int.Parse(Console.ReadLine());
            oPassword = new Password(tamanio);

            //Mostrar el valor del password:
            Console.WriteLine("El valor del password es: " + oPassword.Valor);
            Console.WriteLine("Es fuerte?" + (oPassword.EsFuerte() ? "SI" : "NO"));

            uPrueba.ResetPass(oPassword);

            //PARTE B: [SITIO] -1..*>[USUARIO]
            Sitio oSitio = new Sitio(10);
            oSitio.RegistrarAltaUsuario(uPrueba);

            Usuario[] usuariosPassDebil = oSitio.ListarUsuarioPassDebil();

            Console.WriteLine("Usuarios con pass debil registrados en el sitio:");
            for (int i = 0; i < usuariosPassDebil.Length; i++)
            {
                if (usuariosPassDebil[i] != null)
                    Console.WriteLine("Usuario: " + usuariosPassDebil[i].Email);
            }
        }
    }
}