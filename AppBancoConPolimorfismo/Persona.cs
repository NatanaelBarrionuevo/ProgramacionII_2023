using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Persona
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int documento;

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        private bool sexo;  //true->Masculino false->Femenino

        public bool Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public Persona()
        {
            nombre = string.Empty;
            documento = 0;
            sexo = true;
        }
        public Persona(string nombre, int documento, bool sexo)
        {
            this.nombre = nombre;
            this.documento = documento;
            this.sexo = sexo;
        }
        public string SexoToString()
        {
            //if (sexo == true)
            //    return "Masculino";
            //else
            //    return "femeninon";
            return sexo ? "Masculino" : "Femenino";
        }
        public override string ToString()
        {
            return "|Nombre: " + this.nombre + " |Documento: " + this.documento + " |Sexo: " + this.SexoToString();
        }
    }
}
