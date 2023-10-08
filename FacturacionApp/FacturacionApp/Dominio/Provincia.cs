﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Dominio
{
    public class Provincia
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Provincia(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
