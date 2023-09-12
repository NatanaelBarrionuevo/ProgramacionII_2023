using System;
using CarpinteriaApp_1w3.Presentacion;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp_1w3
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoPresupuesto Nuevo = new FrmNuevoPresupuesto();
            Nuevo.ShowDialog();

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarPresupuestos consulta = new FrmConsultarPresupuestos();
            consulta.ShowDialog();
        }
    }
}
