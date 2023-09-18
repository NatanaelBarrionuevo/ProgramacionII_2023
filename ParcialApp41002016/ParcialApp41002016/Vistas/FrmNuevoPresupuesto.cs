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
    public partial class FrmNuevoPresupuesto : Form
    {
        private BDHelper oBDHelper;
        private Presupuesto oPresupuesto;
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
            oBDHelper = new BDHelper();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "CONTROL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            //new FrmConnecion().ShowDialog();
            Habilitar(false);
            cboProductos.Focus();
            lblNuevoPresupuesto.Text = lblNuevoPresupuesto.Text + oBDHelper.ObtenerId("SP_PROXIMO_ID");
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtDescuento.Text = 0.ToString();
            txtDescuento.MaxLength = 3;
            txtCliente.Text = "Consumidor Final";
            txtCliente.MaxLength = 255;
            CargarCombo(cboProductos, "SP_CONSULTAR_PRODUCTOS");

        }
        private void CargarCombo(ComboBox cbo, string SP)
        {
            DataTable tabla = oBDHelper.ConsultarTabla(SP);
            cbo.DataSource = tabla;
            if(tabla.Rows.Count > 0)
            {
                cbo.ValueMember = tabla.Columns[0].ColumnName;
                cbo.DisplayMember = tabla.Columns[1].ColumnName;
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach(DataRow row in tabla.Rows )
                {
                    if ((int)row.ItemArray[3] == 0)
                    {
                        cboProductos.Items.RemoveAt((int)row.ItemArray[0] - 1);
                    }
                }
            }
            
        }
        private void Habilitar(bool b)
        {
            txtFecha.Enabled = b;
            txtDescuento.Enabled = b;
            btnAgregar.Enabled = b;
            txtSubtotal.Enabled = b;
            txtTotal.Enabled = b;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Repite();

            if (ValidarDatos())
            {
                DataRowView item = (DataRowView)cboProductos.SelectedItem;
                int cod_presupuesto = oPresupuesto.Cod_presupuesto;
                int cod_articulo = Convert.ToInt32(item.Row.ItemArray[0]);
                string producto = item.Row.ItemArray[1].ToString();
                double precio = (double)item.Row.ItemArray[2];
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                Articulo articulo = new Articulo(cod_articulo, producto, precio);
                DetallePresupuesto dp = new DetallePresupuesto(cod_presupuesto, articulo, cantidad);

                oPresupuesto.Fecha = Convert.ToDateTime(txtFecha.Text).ToLocalTime();
                oPresupuesto.Cliente = txtCliente.Text;
                oPresupuesto.Descuento = Convert.ToInt32(txtDescuento.Text);

                oPresupuesto.AgregarDetalle(dp);

                dgvDetalle.Rows.Add(new object[] { cod_articulo, producto, precio, cantidad, "Quitar" });

                txtSubtotal.Text = dp.CalcularSubtotales().ToString();

                Total();


            }
        }
        private void Total()
        {
            double aux = oPresupuesto.CalcularTotales();
            txtTotal.Text = ((aux * Convert.ToDouble(txtDescuento)) / 100).ToString();
            oPresupuesto.Monto = Convert.ToDouble(txtTotal.Text);
        }


        private bool ValidarDatos()
        {
            if (cboProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe SELECCIONAR al menos un producto", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cboProductos.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _) || Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("No hay CANTIDADES seleccionadas o no se ingreso un numero natural", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtCantidad.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescuento.Text) || !int.TryParse(txtDescuento.Text, out _) || Convert.ToInt32(txtDescuento.Text) < 0)
            {
                MessageBox.Show("Debe SELECCIONAR al menos un producto", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtDescuento.Focus();
                return false;
            }

            return true;
        }

        private void Repite()
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["ColCod"].Value.Equals(cboProductos.SelectedValue))
                {
                    if (MessageBox.Show("El producto ya ha sido agregado, DESEA SUMAR LAS CANTIDADES?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (DetallePresupuesto dt in oPresupuesto.Detalle)
                        {
                            if (dt.Articulo.Cod_articulo.Equals(cboProductos.SelectedValue))
                            {
                                dt.Cantidad += Convert.ToInt32(txtCantidad.Text);
                                txtCantidad.Text = 0.ToString();
                                txtCantidad.Focus();
                            }

                        }
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {

                if (oBDHelper.AgregarPresupuesto("SP_INSERTAR_MAESTRO", oPresupuesto, "SP_INSERTAR_DETALLE "))
                {
                    MessageBox.Show("El presupuesto ha sido cargado exitosamente!! Que tenga un buen día.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("El presupuesto NO ha podido ser cargado!! Porfavor, intente de nuevo mas tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

        }

        private bool ValidarDetalle()
        {
            if (dgvDetalle.Rows.Count <= 0)
            {
                MessageBox.Show("Debe AGREGAR AL MENOS UN DETALLE PARA INGRESAR EL PRESUPUESTO");
                dgvDetalle.Focus();
                return false;
            }
            return true;
        }

        private void Limpiar()
        {
            dgvDetalle.Rows.Clear();
            txtCantidad.Text = 0.ToString();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                oPresupuesto.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
                MessageBox.Show("El detalle a sido removido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                dgvDetalle.Focus();
            }
        }
    }
}
