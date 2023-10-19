using FacturacionApp.Dominio;
using FacturacionApp.Servicios.Implementaciones;
using FacturacionApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionApp.Vistas.Soporte.Cliente
{
    public partial class FrmClienteAlta : Form
    {
        private IServicio servicio;
        public FrmClienteAlta()
        {
            InitializeComponent();
            servicio = new Servicio();
        }

        private void FrmClienteAlta_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            txtFecha.Text = DateTime.Now.ToShortDateString();
            CargarProvincias();
        }

        private void Habilitar(bool x)
        {
            txtFecha.Enabled = x;
            cboBarrio.Enabled = x;
        }

        private void CargarProvincias()
        {
            cboProvincia.DataSource = servicio.ObtenerProvincias();
            cboProvincia.ValueMember = "Codigo";
            cboProvincia.DisplayMember = "Nombre";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta segur@ que DESEA SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
            
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cboProvincia.Text) || Convert.ToInt32(cboProvincia.SelectedValue) > -1)
            {
                cboProvincia.Enabled = true;
                Provincia oProvincia = (Provincia)cboProvincia.SelectedItem;
                CargarBarrios(oProvincia);
            }
        }
        
        private void CargarBarrios(Provincia provincia)
        {
            cboBarrio.DataSource = servicio.ObtenerBarrios(provincia);
            cboBarrio.ValueMember = "Codigo";
            cboBarrio.DisplayMember = "Nombre";
        }
    }
}
