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

namespace ParcialApp41002016.Vistas
{
    public partial class FrmConnecion : Form
    {
        BDHelper gestor;
        public FrmConnecion()
        {
            InitializeComponent();
            gestor = new BDHelper();
        }

        private void FrmConnecion_Load(object sender, EventArgs e)
        {
            txtConeccion.Text = string.Empty;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConeccion.Text))
            {
                MessageBox.Show("No ha ingresado ninguna cadena de coneccion.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtConeccion.Focus();
                return;
            }
            if (!txtConeccion.Text.Contains("@\"Data Source=\"") && !txtConeccion.Text.Contains("; Initial Catalog ="))
            {
                MessageBox.Show("Debe contene al menos, \"Data Source=\"", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtConeccion.Focus();
                return;
            }

            gestor.Stringcnn = txtConeccion.Text;
            this.Dispose();

            
        }
        
        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En el area de texto, porfavor, ingrese la cadena de texto necesaria para la coneccion con la BD de SQL-Server con la cual quiera cobectar este formulario.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

    }
}
