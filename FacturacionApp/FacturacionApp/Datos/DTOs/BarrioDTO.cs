﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Datos.DTOs
{
    public class BarrioDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        

        public BarrioDTO(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
           
        }
    }
}
