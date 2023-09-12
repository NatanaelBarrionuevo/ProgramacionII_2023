using CarpinteriaApp_1w3.Datos;
using CarpinteriaApp_1w3.Entidades;
using System;
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
    public partial class FrmNuevoPresupuesto : Form
    {
        Presupuesto nuevo;
        DBHelper helper;
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
            nuevo = new Presupuesto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //validar...
            if(string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Debe ingresar un cliente..", "CONTROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(dgvDetalles.Rows.Count == 0) 
            {
                MessageBox.Show("Debe ingresar al menos un Producto..", "CONTROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //grabar el presupuesto Maestro-Detalle {}
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDescuento.Text);

            if(helper.ConfirmarPresupuesto(nuevo)) 
            {
                MessageBox.Show("El presupuesto se registro con exito..", "INFORME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else 
            {
                MessageBox.Show("El presupuesto no puedo registrarse..", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            helper = new DBHelper();
            
            CargarProductos();
            txtFecha.Text = DateTime.Today.ToString();
            txtCliente.Text = "Consumidor Final";
            txtCliente.Text= "0";
            txtCantidad.Text = "1";

            lblPresupuestoNro.Text = lblPresupuestoNro.Text + " " + helper.ProximoPresupuesto();
        }

        private void CargarProductos()
        {
            DataTable tabla = helper.Consultar("SP_CONSULTAR_PRODUCTOS");

            cboProducto.DataSource = tabla;
            cboProducto.DisplayMember = tabla.Columns[1].ColumnName;
            cboProducto.ValueMember = tabla.Columns[0].ColumnName;

        }

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboProducto.SelectedIndex== -1) 
            {
            MessageBox.Show("Debe seleccionar un producto...", "Control",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;
                
            }
            if (string.IsNullOrEmpty(txtCantidad.Text)|| !int.TryParse(txtCantidad.Text,out _)) 
            {
                MessageBox.Show("Debe ingresar una cantidad minima...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantidad.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if(fila.Cells["ColProducto"].Value.Equals(cboProducto.Text)) 
                {
                    MessageBox.Show("este producto ya esta presupuestado...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   cboProducto.Focus();
                    return;

                }
            }
            DataRowView item = (DataRowView)cboProducto.SelectedItem;

            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string  nom = item.Row.ItemArray[1].ToString();
            double pre= Convert.ToDouble(item.Row.ItemArray[2].ToString());
            Producto p = new Producto(nro,nom,pre  );
            // string pro = item.Row.ItemArray[3].ToString();

            int cant = Convert.ToInt32(txtCantidad.Text);
            DetallePresupuesto detalle = new DetallePresupuesto(p,cant);

            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(detalle.Producto.ProductoNro,  
                                  detalle.Producto.Nombre,
                                  detalle.Producto.Precio,
                                  detalle.Cantidad,"quitar");

            calcularTotales();

        }

        private void calcularTotales()
        {
            txtSubTotal.Text = nuevo.CalcularTotal().ToString();
            if(!string.IsNullOrEmpty(txtDescuento.Text) && !int.TryParse(txtDescuento.Text, out _))
            {    
                double dto = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text)/100;
                txtTotal.Text= (nuevo.CalcularTotal()-dto).ToString();
            }
                

        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex== 4) 
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                calcularTotales();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
