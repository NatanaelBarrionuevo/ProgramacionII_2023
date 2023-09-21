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
        //private BDHelper gestor;
        private Presupuesto oPresupuesto;
        private int resultado = 0;
        
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
            
            oPresupuesto = new Presupuesto();
            
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
            
            lblNuevoPresupuesto.Text = lblNuevoPresupuesto.Text + BDHelper.ObetenerInstancia().ObtenerId("SP_PROXIMO_ID");
            txtFecha.Text = DateTime.Now.ToShortDateString();
            LoaderPantalla();
        }
        private void LoaderPantalla()
        {
            Habilitar(false);
            cboProductos.Focus();         
            
            txtDescuento.Text = 0.ToString();
            txtDescuento.MaxLength = 3;
            txtCliente.Text = "Consumidor Final";
            txtCliente.MaxLength = 255;
            CargarProductos();
        }
        private void CargarProductos()
        {
            DataTable tabla = BDHelper.ObetenerInstancia().Consultar("SP_CONSULTAR_PRODUCTOS");
            cboProductos.DataSource = tabla;
            cboProductos.ValueMember = tabla.Columns[0].ColumnName;
            cboProductos.DisplayMember = tabla.Columns[1].ColumnName;
        }
        private void Habilitar(bool b)
        {
            txtFecha.Enabled = b;
            txtDescuento.Enabled = b;
            // btnAgregar.Enabled = b;
            txtSubtotal.Enabled = b;
            txtTotal.Enabled = b;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            

            if (ValidarDatos())
            {
                Repite();
                CrearFila(resultado);
                
                Total();
                resultado = 0;
            }
        }
        private void Total()
        {
            txtSubtotal.Text = oPresupuesto.CalcularTotales().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                double desc = oPresupuesto.CalcularTotales() * Convert.ToDouble(txtDescuento.Text) / 100;
                txtTotal.Text = (oPresupuesto.CalcularTotales() - desc).ToString();
            }

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

        public void CrearFila(int x)
        {
            DataRowView item = (DataRowView)cboProductos.SelectedItem;

            oPresupuesto.Cod_presupuesto = BDHelper.ObetenerInstancia().ObtenerId("SP_PROXIMO_ID");
            int cod_presupuesto = oPresupuesto.Cod_presupuesto;
            int cod_articulo = Convert.ToInt32(item.Row.ItemArray[0]);
            string producto = item.Row.ItemArray[1].ToString();
            double precio = Convert.ToDouble(item.Row.ItemArray[2]);
            int cantidad;
            if (x == 0)
            {                
                cantidad = Convert.ToInt32(txtCantidad.Text);                
            }
            else
            {
                cantidad = x;
            }
            Articulo articulo = new Articulo(cod_articulo, producto, precio);
            DetallePresupuesto dp = new DetallePresupuesto(cod_presupuesto, articulo, cantidad);

            oPresupuesto.Fecha = Convert.ToDateTime(txtFecha.Text).ToLocalTime();
            oPresupuesto.Cliente = txtCliente.Text;
            oPresupuesto.Descuento = Convert.ToInt32(txtDescuento.Text);

            oPresupuesto.AgregarDetalle(dp);

            dgvDetalle.Rows.Add(new object[] { cod_articulo, producto, precio, cantidad, "Quitar" });
        }
        private void Repite()
        {

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["ColCod"].Value.Equals(cboProductos.SelectedValue))
                {
                    int indice = dgvDetalle.CurrentRow.Index;
                    object []aux = new object[] { dgvDetalle.Rows[indice].Clone() };

                    if (MessageBox.Show("El producto ya ha sido agregado, DESEA SUMAR LAS CANTIDADES?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        dgvDetalle.Rows.RemoveAt(indice);
                        foreach(DetallePresupuesto dt in oPresupuesto.Detalle)
                        {
                            if (row.Cells[0].Value.Equals(dt.Articulo.Cod_articulo))
                            {
                                resultado = Convert.ToInt32(txtCantidad.Text) + dt.Cantidad;
                            }
                        }
                        oPresupuesto.QuitarDetalle(indice);
                        
                    }
                }
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            oPresupuesto.Monto = Convert.ToDouble(txtTotal.Text);
            if (ValidarDetalle())
            {

                if (BDHelper.ObetenerInstancia().AgregarMaestroDetalle("SP_INSERTAR_MAESTRO", oPresupuesto, "SP_INSERTAR_DETALLE"))
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
            if (dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                oPresupuesto.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
                MessageBox.Show("El detalle a sido removido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                dgvDetalle.Focus();
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblNuevoPresupuesto_Click(object sender, EventArgs e)
        {

        }
    }
}
