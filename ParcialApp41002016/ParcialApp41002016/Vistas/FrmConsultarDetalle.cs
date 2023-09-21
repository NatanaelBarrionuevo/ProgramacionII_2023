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

namespace ParcialApp41002016.Vistas
{
    public partial class FrmConsultarDetalle : Form
    {
        private object[] fila;
       // private BDHelper gestor;
        private Presupuesto oPresupuesto;
        public FrmConsultarDetalle(object[] fila)
        {
            InitializeComponent();
            this.fila = fila;
            //gestor = new BDHelper();
        }

        private void btbSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void FrmConsultarDetalle_Load(object sender, EventArgs e)
        {
            lblDetalle.Text = "Detalle del Presupuesto Nro: " + fila[0];
            lblFecha.Text = "Fecha: " + fila[1];
            lblCliente.Text = "Cliente: " + fila[2];
            lblDescuento.Text = "%Descuento: " + fila[3];
            lblTotal.Text = "Total: " + fila[5];
            LlenarDgv();
        }
        private void LlenarDgv()
        {
            Parametros param = new Parametros("@cod_presupuesto", (int)fila[0]);
            List<Parametros> lista = new List<Parametros>() { param };
            DataTable tabla = BDHelper.ObetenerInstancia().Consultar("SP_CONSULTAR_DETALLES_PRESUPUESTO", lista);
            foreach(DataRow fila in tabla.Rows)
            {
                int presupuesto = (int)fila.ItemArray[0];
                int detalle = (int)fila.ItemArray[1];
                string producto = fila.ItemArray[4].ToString();
                double precio = (double)fila.ItemArray[5];
                int cantidad = (int)fila.ItemArray[3];

                dgvDetalle.Rows.Add(new object[] {presupuesto, detalle, producto, precio, cantidad });
            }
        }

    }
}


