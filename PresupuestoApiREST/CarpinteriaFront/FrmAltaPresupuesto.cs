using Newtonsoft.Json;
using PresupuestoBack.Servicio;
using PresupuestosBack.Dominio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
{
    public partial class FrmAltaPresupuesto : Form
    {
        private IServicio servicio;
        private Presupuesto nuevo;
        public FrmAltaPresupuesto()
        {
            InitializeComponent();
            servicio = new Servicio();
            nuevo = new Presupuesto();


        }

        private async void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            //ProximoPresupuesto();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCliente.Text = "CONSUMIDOR FINAL";
            txtDto.Text = "0";
            this.ActiveControl = cboProductos; // Set foco al combo
            await CargarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProductos.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un PRODUCTO!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("PRODUCTO: " + cboProductos.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }
            Producto p = (Producto)cboProductos.SelectedItem;

            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto detalle = new DetallePresupuesto(p, cantidad);
            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { p.ProductoNro, p.Nombre, p.Precio, cantidad });

            CalcularTotal();
        }

        private async void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();

            }
        }

        private void CalcularTotal()
        {
            double total = nuevo.CalcularTotal();
            txtTotal.Text = total.ToString();

            if (txtDto.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDto.Text)) / 100;
                txtFinal.Text = (total - dto).ToString();
            }
        }

        private async Task CargarProductos()
        {
            HttpClient cliente = new HttpClient();
            string url = "";
            var result = await cliente.GetAsync(url);
            var bodyJSON = await result.Content.ReadAsStringAsync();
            List<Producto> lst = JsonConvert.DeserializeObject<List<Producto>>(bodyJSON);


            cboProductos.DataSource = lst;
            cboProductos.DisplayMember = "ProductoNro";
            cboProductos.ValueMember = "Nombre";

        }

        private void GuardarPresupuesto()
        {
            //datos del presupuesto:
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDto.Text);
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);

            if (servicio.AgregarPresupuesto(nuevo))
            {
                MessageBox.Show("Presupuesto registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarPresupuesto();
        }
    }
}
