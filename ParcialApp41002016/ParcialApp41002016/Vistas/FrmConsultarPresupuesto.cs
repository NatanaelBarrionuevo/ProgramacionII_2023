using ParcialApp41002016.Entidades;
using ParcialApp41002016.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialApp41002016.Vistas
{
    public partial class FrmConsultarPresupuesto : Form
    {
        BDHelper gestor;
        Presupuesto oPresupuesto;
        public FrmConsultarPresupuesto()
        {
            InitializeComponent();
            gestor = new BDHelper();
        }

        private void FrmModificarPresupuesto_Load(object sender, EventArgs e)
        {
            txtCliente.MaxLength = 255;
            //txtCliente.Text = string.Empty;
            txtCliente.Text = "Consumidor Final";
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            Habilitar(true);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Habilitar(false);
                Parametros param1 = new Parametros("@fecha_desde", dtpDesde.Value);
                Parametros param2 = new Parametros("@fecha_hasta", dtpHasta.Value);
                Parametros param3 = new Parametros("@cliente", txtCliente.Text.ToString());

                List<Parametros> lista = new List<Parametros>() { param1, param2, param3 };


                DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRESUPUESTOS", lista);

                //dgvDetalle.DataSource = lista;
                foreach (DataRow fila in tabla.Rows)
                {
                    int cod_presupuesto = Convert.ToInt32(fila.ItemArray[0]);
                    string fechaAlta = fila.ItemArray[1].ToString();
                    string cliente = fila.ItemArray[2].ToString();
                    int descuento = Convert.ToInt32(fila.ItemArray[3]);
                    string fechaBaja = fila.ItemArray[4].ToString();
                    double total = Convert.ToDouble(fila.ItemArray[5]);
                    dgvDetalle.Rows.Add(new object[] { cod_presupuesto, fechaAlta, cliente, descuento, fechaBaja, total, "Ver Detalle" });
                }
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtCliente.Text) || int.TryParse(txtCliente.Text, out _))
            {
                MessageBox.Show("Debe INGRESAR UN CLIENTE valido.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtCliente.Focus();
                return false;
            }
            if (!dtpDesde.Checked && !dtpHasta.Checked)
            {
                MessageBox.Show("Debe SELECCIONAR UNA FECHA.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                dtpHasta.Focus();
                dtpDesde.Focus();
                return false;
            }
            if (dtpDesde.Value > DateTime.Now || dtpHasta.Value > DateTime.Now)
            {
                MessageBox.Show("Debe SELECCIONAR UNA FECHA VALIDA.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                dtpHasta.Focus();
                dtpDesde.Focus();
                return false;
            }

            return true;
        }

        private void Habilitar(bool x)
        {
            dtpDesde.Enabled = x;
            dtpHasta.Enabled = x;
            txtCliente.Enabled = x;
            btnBuscar.Enabled = x;
            btnReanudar.Enabled = !x;
        }
        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDetalle.CurrentCell.ColumnIndex == 6 && dgvDetalle.CurrentRow != null)
            {
                int cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                new FrmConsultarDetalle(cod_presupuesto).ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod_presupuesto = 0;
            if (dgvDetalle.CurrentRow != null)
            {
                cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                if (MessageBox.Show("Esta seguro que desea ELIMINAR ESTE PRESUPUESTO?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (cod_presupuesto > 0 && gestor.BajaPresupuesto(cod_presupuesto))
                    {
                        MessageBox.Show("El Presupuesto a sido eliminado exitosamente, que tenga un buen dia !.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("El Presupuesto NO AH PODIDO SER ELIMINADO, disculpe las molestias. Intente nuevamente o consulte con el administrador.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cod_presupuesto = 0;
            if (dgvDetalle.CurrentRow != null)
            {
                cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                new FrmModificarPresupuesto(cod_presupuesto).ShowDialog();

            }
        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            dgvDetalle.Rows.Clear();
        }
    }
}
