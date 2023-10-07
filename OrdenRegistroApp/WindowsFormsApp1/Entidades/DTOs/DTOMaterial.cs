using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenRetiro.Entidades.DTOs
{
    public class DTOMaterial
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }

        public DTOMaterial()
        {
                
        }
    }
}
