using ParcialApp41002016.Entidades;
using ParcialApp41002016.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialApp41002016.Vistas.Cliente
{
    public partial class FrmAgregarCliente : Form
    {
        private BDHelper gestor;
        private Clientes cliente;
        public FrmAgregarCliente()
        {
            InitializeComponent();
            gestor = new BDHelper();
            cliente = new Clientes();
            
        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            lblCliente.Text = "Cliente: " + gestor.ObtenerId("SP_PROXIMO_CLIENTE");
            Loader();
            
        }

        private void Loader()
        {
            txtApellido.MaxLength = 50;
            txtNombre.MaxLength = 50;
            txtDomicilio.MaxLength = 50;
            txtAltura.MaxLength = 4;
            txtTelefono.MaxLength = 12;
            txtEmail.MaxLength = 50;            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtAltura.Text) || !int.TryParse(txtAltura.Text, out _) || string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                MessageBox.Show("La altura ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtAltura.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt.Text) || !int.TryParse(txtAltura.Text, out _) || string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                MessageBox.Show("La altura ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtAltura.Focus();
                return false;
            }
            return true;
        }
    }
}
