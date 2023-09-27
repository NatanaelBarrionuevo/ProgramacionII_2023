using ParcialApp41002016.Entidades;
using ParcialApp41002016.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialApp41002016.Vistas.Cliente
{
    public partial class FrmClientes : Form
    {
        private Clientes cliente;
        private BDHelper gestor;
        public FrmClientes()
        {
            InitializeComponent();
            gestor = new BDHelper();
            cliente = new Clientes();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "CONTROL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            CargarClientes();
        }

        private void CargarClientes()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_CLIENTES");
            foreach (DataRow row in tabla.Rows)
            {
                //if (Convert.ToInt32(row.ItemArray[9]) == 1)
                //{
                    int cod_cliente = Convert.ToInt32(row.ItemArray[0]);
                    string cliente = row.ItemArray[1] + ", " + row.ItemArray[2];
                    dgvClientes.Rows.Add(new object[] { cod_cliente, cliente, "Modificar" });
                //}
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new FrmAgregarCliente().ShowDialog();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 2 && dgvClientes.CurrentRow != null)
            {
                int legajo = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value);
                new FrmModificarCliente(legajo).ShowDialog();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea ELIMINAR ESTE CLIENTE?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int legajo = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value);
                if (gestor.EliminarCliente("SP_ELIMINAR_CLIENTE", legajo))
                {
                    MessageBox.Show("El cliente ah sido elimado exitosamente, que tenga un buen dia!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else 
                {
                    MessageBox.Show("El cliente NO AH PODIDO SER ELIMINADO, porfavor intente de nuevo mas tarde o contacte con al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                        , MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
