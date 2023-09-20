using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpinteriaApp.dominio;

namespace CarpinteriaApp.datos
{
    public interface IDaoProductos
    {
        //QUE VA A HACER, UN GET ALL.

        List<Producto> GetAll();

        //solomente tiene el get all porque el contrato es traer datos para llenar combos o dgv
    }
}
