using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
namespace CarpinteriaApp.Servicios
{
    public class GestorProducto
    {
        //Clase que va a tener tantos metodos como servicios tenga que hacer la pantalla.
        IDaoProductos dao;//dependencia de DAO, alguien se lo tiene que dar (es una asociacion tengo como atributo privado un objeto e otra clase)
        //Dos formas de resolver, o tengo un seter o por constructor (esto se llama inyeccion de dependencia)

        public GestorProducto(IDaoProductos dao)
        {
            this.dao = dao;
        }

        public List<Producto> ObtenerProductos()
        {

            return dao.GetAll();
        }
    }//ESTA LISTA LA CLASESITA QUE DA PARA ARRIBAY PARA ABAJO POR REQUERIMIENTOS.
}
