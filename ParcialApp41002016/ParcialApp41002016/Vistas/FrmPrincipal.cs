using ParcialApp41002016.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialApp41002016
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desa SALIR?", "CONTROL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void nuevoPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmNuevoPresupuesto().ShowDialog();
        }

        private void modiificarPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmModificarPresupuesto().ShowDialog();
        }

        private void eliminarPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmEliminarPresupuesto().ShowDialog();
        }
    }
}
