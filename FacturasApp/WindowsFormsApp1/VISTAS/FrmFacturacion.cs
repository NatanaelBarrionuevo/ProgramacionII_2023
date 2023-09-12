using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1
{
    public partial class FrmFacturacion : Form
    {
        Facturas nueva;
        DBHelper oDBHelper;

        public FrmFacturacion()
        {
            InitializeComponent();
            nueva = new Facturas();
            oDBHelper = new DBHelper();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            lblNroFactura.Text = "Nro Factura: " + oDBHelper.CargarNro().ToString();

            DataTable tabla = oDBHelper.Consultar("SP_ARTICULOS");
            cboArticulo.DataSource = tabla;
            cboArticulo.ValueMember = tabla.Columns[0].ColumnName;
            cboArticulo.DisplayMember = tabla.Columns[1].ColumnName;
            cboArticulo.DropDownStyle = ComboBoxStyle.DropDownList;

            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "0";

        }

        private void Habilitar(bool x)
        {

            txtFecha.Enabled = x;
            txtSubtotal.Enabled = x;
            txtTotal.Enabled = x;

        }
        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int num = 0;
            string nombre = string.Empty;
            double precio = 0;
            int cantidad = 0;
            bool activo;
            DataRowView item = (DataRowView)cboArticulo.SelectedItem;
            Articulos a = new Articulos(num, nombre, precio);
            detalleFacturas detalle = new detalleFacturas(a, precio, cantidad);

            if (ValidarDatos())
            {
                num = Convert.ToInt32(item.Row.ItemArray[0]); //el ID del articulo 
                nombre = item.Row.ItemArray[1].ToString(); //Articulo
                precio = Convert.ToDouble(item.Row.ItemArray[2]); //Precio del articulo 

                activo = (bool)item.Row.ItemArray[4];//activo?

                if (activo)
                {
                    cantidad = Convert.ToInt32(txtCantidad.Text);//Cantidad

                    nueva.AgregarDetalle(detalle); //AGREGO LA FILA COLUMNA POR COLUMNA

                    dgvDetalle.Rows.Add(detalle.Articulo.Id,
                                        detalle.Articulo.Nombre,
                                        detalle.Precio_venta,
                                        detalle.Cantidad,
                                        "Quitar");

                }
                else
                {
                    MessageBox.Show("ERROR EN EL SISTEMA, INTENTE MAS TARDE.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    cboArticulo.Focus();
                }
            }





            CalcularTotales();

        }





        private void CalcularTotales()
        {

            txtSubtotal.Text = nueva.CalcularTotal().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _)) //SI NO ESTA VACIO Y SE PUEDE CONVERTIR EN UN ENTERO
            {
                double descuento = nueva.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
                txtTotal.Text = Convert.ToString(nueva.CalcularTotal() - descuento);

            }

        }

        private bool ValidarDatos()
        {
            if (cboArticulo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un articulo.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                cboArticulo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe seleccionar cantidades.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtCantidad.Focus();
                return false;
            }
            if (int.Parse(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad valida.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtCantidad.Focus();
                return false;
            }
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {

                if (fila.Cells["ColArticulo"].Value.ToString().Equals(cboArticulo.Text))
                {
                    MessageBox.Show("Este ARTICULO esta REPETIDO.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboArticulo.Focus();
                    return false;


                }



            }


            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 4) // POSICIONARSE EN LA COLUMNA ACCIONES (CONTANDO DESDE EL 0)
            {
                nueva.QuitarDetalle(dgvDetalle.CurrentRow.Index); //Quitar el de esta posicion (DE LA FILA)

                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);

                CalcularTotales();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
