using CarpinteriaApp_1w3.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp_1w3.Presentacion
{
    public partial class FrmConsultarPresupuestos : Form
    {
        public FrmConsultarPresupuestos()
        {
            InitializeComponent();
        }

        private void FrmConsultarPresupuestos_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //validar datos de entrada...
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("@fecha_desde", dtpDesde.Value.ToString("yyyy-MM-dd")));
            lista.Add(new Parametros("@fecha_hasta", dtpHasta.Value.ToString("yyyy-MM-dd")));
            lista.Add(new Parametros("@cliente",txtCliente.Text));

            DataTable tabla = new DBHelper().Consultar("SP_CONSULTAR:PRESUPUESTOS");
            dgvPresupuestos.Rows.Clear();
            foreach(DataRow fila in tabla.Rows) 
            {
                dgvPresupuestos.Rows.Add(new object[] { fila["presupuesto_nro"].ToString(),
                                                        ((Datetime(fila["fecha"]).ToShortDateString(),
                                                        fila["cliente"].ToString(),
                                                        fila["total"].ToString()});
            }

        }
    }
}
