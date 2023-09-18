using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    public class Usuario
    {
		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		private DateTime fechaAta;

		public DateTime FechaAta
        {
			get { return fechaAta; }
			set { fechaAta = value; }
		}

		private Password password;

		public Password Password
        {
			get { return password; }
			set { password = value; }
		}

        public Usuario(string email)
        {
			Email = email;
			//this.email = email;
			fechaAta = DateTime.Now;
			password = null;
        }

        public Usuario(string email, Password pass):this(email)
        {
              password = pass;
        }

		public void ResetPass(Password pass)
		{
			Password = pass;
		}

    }
}
