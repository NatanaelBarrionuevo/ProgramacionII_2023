using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    internal class Sitio
    {
        private string url;
        private Usuario[] usuarios; // declaramos como atributo privado un vector de objetos usuarios
        private int proximo;


        //atajo: ctor+tab
        public Sitio(int n)
        {
            proximo = 0;
            url = String.Empty;
            usuarios = new Usuario[n];
        }

        public Sitio(int n, string url) : this(n)
        {
            this.url = url;

        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public bool RegistrarAltaUsuario(Usuario nuevo) //addContenido(unContenido)
        {
            bool agregado = false;
            if(proximo < usuarios.Length)
            {
                usuarios[proximo] = nuevo;
                proximo++;
                agregado = true;
            }

            return agregado;
        }

        /** Permite retornar el listado de usuarios con Password debil
         **/

        public Usuario[] ListarUsuarioPassDebil()
        {
            Usuario[] vec = new Usuario[usuarios.Length];
            int j = 0;


            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] != null && usuarios[i].Password.EsFuerte()==false)
                {
                    vec[j] = usuarios[i];
                    j++;
                }
            }
            
            return vec;
        }

    }
}
