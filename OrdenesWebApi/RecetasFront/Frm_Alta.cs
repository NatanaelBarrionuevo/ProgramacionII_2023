
using Newtonsoft.Json;
using OrdenesBack.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasFront.Presentacion
{
    public partial class Frm_Alta : Form
    {

        public Frm_Alta()
        {
            InitializeComponent();

        }




        private void btnAceptar_Click(object sender, EventArgs e)
        {

          //completar...
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();

            }
            else
            {
                return;
            }
        }

        private async void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
            //No lleva TASK porque no tiene tarea que realizar, usa la tarea que realiza el metodo.
            //ESTE METODO ESPERA A QUE SE RELAIZA ASINCRONICAMNETE UNA TAREA.
        }

        private async Task CargarComboAsync()
        {
            
            string url = "https://localhost:7046/api/Ordenes/Materiales";
            HttpClient cliente = new HttpClient();

            //await sirve para interrumpir la ejecucuon linea a linea y esperar hasta que el metodo asincrono se complete.
            //var variable sin tipo definido a priori. Es el compialdor el que tiene que inferir el tipo de acuerpdo a la expresion de asignacion que tiene a su derecha.
            //Cuando doy respuesta a un pedido Http, devuelvo JSON como body de la respuesta, pero además
            //devuelvo un response, los header y el codigo de estado al cliente que genero el pedido.
            //REGAL BÁSICA EN LA EJECUCIÓN ASINCRONA DE UN METODO, si algo dentro del metodo es asincrono, el METODO ES ASINCRONO.
            //TODA LA CADENA DE LLAMADA DEBE ASINCRONA CUANDO EJECUTEMOS ALGO ASINCRONO. Es lógico porque no puede venir ejecutando sincronicamente (linae por linea de nuestro codigo fuente)
            //si derepente me topo con algo asincrono, de ahi para abajo la ejecucion será asincrona. Porque sino el RunTime(COMPILADOR) no puede compilar
            //Por convencion a los metodos que son asincronos les ponemos el sufijo async.
            //¿Por qué TASK? Devuleve una tarea en realidad

            var result = await cliente.GetAsync(url);

            var bodyJSON = await result.Content.ReadAsStringAsync();

            //Dentro del contenido del resultado del pedido Http a través del método GET, viene el body de la respuesta.
            //¿Cómo la leemos?Podemos obtener un flujo binario o un array binario, como tambien un STRING.
            //Ahora, obtener la respuesta completa com ouna cadena, como un JSON, tambien es una
            //operacion ASINCRONICA, por ende debemos await (aguardar)

            //Ahora toca deserailizar el JSON que viene como respuesta en el body del pedido Get
            //Usamos la NuGet Newtonsoft.Json, para deserializar y convertir a objeto la notacion JSON
            //Especificamente a una lista de Materiales. Le podemos parametrizar al Deserialize que objeto queremos.

            List<Material> lst = JsonConvert.DeserializeObject<List<Material>>(bodyJSON);

            cboMateriales.DataSource = lst;
            cboMateriales.ValueMember = "Codigo";
            cboMateriales.DisplayMember = "Nombre";
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //completar...
        }

        private bool ExisteProductoEnGrilla(string text)
        {
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["producto"].Value.Equals(text))
                    return true;
            }
            return false;
        }

       



        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 5)
            {
               //completar...
            }
        }
    }
}
