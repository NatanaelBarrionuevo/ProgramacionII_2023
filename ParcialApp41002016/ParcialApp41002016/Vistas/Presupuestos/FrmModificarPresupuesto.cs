using ParcialApp41002016.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcialApp41002016.Vistas;
using ParcialApp41002016.Servicios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.NetworkInformation;

namespace ParcialApp41002016.Vistas
{
    public partial class FrmModificarPresupuesto : Form
    {
        private Presupuesto oPresupuesto;
        private int cod_presupuesto;
        private int resultado;
        private BDHelper gestor;

        public FrmModificarPresupuesto(int cod_presupuesto)
        {
            InitializeComponent();
            this.cod_presupuesto = cod_presupuesto;
            resultado = 0;
            oPresupuesto = new Presupuesto();
            gestor = new BDHelper();
        }

        private void FrmModificarPresupuesto_Load(object sender, EventArgs e)
        {
            lblNuevoPresupuesto.Text = "Presupuesto Numero: " + cod_presupuesto;
            LoaderPantalla();
            Parametros param = new Parametros("@presupuesto_nro", cod_presupuesto);
            List<Parametros> lista = new List<Parametros>() { param };
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_DETALLES_PRESUPUESTO", lista);

            Articulo articulo;
            DetallePresupuesto dt;
            string cliente = string.Empty;
            DateTime fecha = DateTime.Now;
            string total = string.Empty;
            int descuento = 0;
            foreach (DataRow fila in tabla.Rows)
            {

                int presupuesto = (int)fila.ItemArray[0];
                int detalle = (int)fila.ItemArray[1];
                int cod_art = (int)fila.ItemArray[2];
                string producto = fila.ItemArray[4].ToString();
                double precio = Convert.ToDouble(fila.ItemArray[5]);
                int cantidad = (int)fila.ItemArray[3];

                cliente = fila.ItemArray[6].ToString();
                fecha = Convert.ToDateTime(fila.ItemArray[7]);
                total = fila.ItemArray[8].ToString();
                descuento = Convert.ToInt32(fila.ItemArray[9]);

                articulo = new Articulo();
                articulo.Cod_articulo = cod_art;
                articulo.Nombre = producto;
                articulo.Precio = precio / 1.3;

                dt = new DetallePresupuesto();
                dt.Cod_presupuesto = cod_presupuesto;
                dt.Cod_detalle = detalle;
                dt.Articulo = articulo;
                dt.Cantidad = cantidad;

                oPresupuesto.AgregarDetalle(dt);
                dgvDetalle.Rows.Add(new object[] { cod_art, producto, precio, cantidad, "Quitar" });
            }
            txtFecha.Text = fecha.ToShortDateString();
            txtCliente.Text = cliente;
            txtDescuento.Text = descuento.ToString();
            Total();

            oPresupuesto.Cod_presupuesto = cod_presupuesto;
            oPresupuesto.Descuento = descuento;
            oPresupuesto.Fecha = fecha;
        }
        private void LoaderPantalla()
        {
            Habilitar(false);
            cboProductos.Focus();


            txtDescuento.MaxLength = 3;

            txtCliente.MaxLength = 255;
            CargarProductos();
        }
        private void Habilitar(bool b)
        {
            txtFecha.Enabled = b;
            txtDescuento.Enabled = b;
            // btnAgregar.Enabled = b;
            txtSubtotal.Enabled = b;
            txtTotal.Enabled = b;
        }
        private void CargarProductos()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRODUCTOS");
            cboProductos.DataSource = tabla;
            cboProductos.ValueMember = tabla.Columns[0].ColumnName;
            cboProductos.DisplayMember = tabla.Columns[1].ColumnName;
        }



        private void btnAgregar_Click_1(object sender, EventArgs e)
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

        private void CrearFila(int x)
        {
            if (resultado >= 0)
            {
                DataRowView item = (DataRowView)cboProductos.SelectedItem;

                oPresupuesto.Cod_presupuesto = cod_presupuesto;

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
             
                oPresupuesto.AgregarDetalle(dp);

                dgvDetalle.Rows.Add(new object[] { cod_articulo, producto, dp.Articulo.Precio * 1.3, cantidad, "Quitar" });
            }
            else
            {
                cboProductos.Focus();
            }
        }
        private void Repite()
        {

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["ColCod"].Value.Equals(cboProductos.SelectedValue))
                {
                    int indice = dgvDetalle.CurrentRow.Index;
                    object[] aux = new object[] { dgvDetalle.Rows[indice].Clone() };

                    if (MessageBox.Show("El producto ya ha sido agregado, DESEA SUMAR LAS CANTIDADES?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        dgvDetalle.Rows.RemoveAt(indice);
                        foreach (DetallePresupuesto dt in oPresupuesto.Detalle)
                        {
                            if (row.Cells[0].Value.Equals(dt.Articulo.Cod_articulo))
                            {
                                resultado = Convert.ToInt32(txtCantidad.Text) + dt.Cantidad;
                            }
                        }
                        oPresupuesto.QuitarDetalle(indice);

                    }
                    else
                    {
                        resultado = -1;
                    }
                }
            }

        }
        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            
            if (ValidarDetalle())
            {
                oPresupuesto.Monto = Convert.ToDouble(txtTotal.Text);
                oPresupuesto.Cliente = txtCliente.Text;
                if (MessageBox.Show("Esta a punto de confirmar la modificacion del resupuesto, DESEA SEGUIR ADELANTE?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<Parametros> lista = new List<Parametros>(){
                    new Parametros("@cliente", oPresupuesto.Cliente),
                    new Parametros("@dto", Convert.ToInt32(oPresupuesto.Descuento)),
                    new Parametros("@total", Convert.ToDouble(oPresupuesto.Monto)),
                    new Parametros("@presupuesto_nro", oPresupuesto.Cod_presupuesto)

                };

                    List<Parametros> lst = new List<Parametros>() {
                        new Parametros("@presupuesto_nro", oPresupuesto.Cod_presupuesto) };


                    if (gestor.Modificar("SP_MODIFICAR_MAESTRO", lista) && gestor.AgregarDetalle("SP_INSERTAR_DETALLE", cod_presupuesto, oPresupuesto))
                    {
                        MessageBox.Show("El presupuesto nro " + cod_presupuesto + "fue MODIFICADO EXITOSAMENTE, que tenga un buen dia", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Limpiar();
                        this.Dispose();
                    }
                    /*if (gestor.ModificarPresupuesto(oPresupuesto))
                    {
                        MessageBox.Show("El presupuesto nro " + cod_presupuesto + "fue MODIFICADO EXITOSAMENTE, que tenga un buen dia", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Limpiar();
                        this.Dispose();
                    }*/
                    else
                    {
                        MessageBox.Show("El presupuesto nro " + cod_presupuesto + " NO AH PODIDO SER MODIFICADO EXITOSAMENTE, intente nuevamente mas tarde o comuniquese con el administrador. Disculpe las molestias.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        btnModificar.Focus();
                    }


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
            if (string.IsNullOrEmpty(txtSubtotal.Text))
            {
                MessageBox.Show("Debe AGREGAR AL MENOS UN DETALLE PARA INGRESAR EL PRESUPUESTO");
                cboProductos.Focus();
                return false;
            }
            return true;
            }

            private void Limpiar()
            {
                dgvDetalle.Rows.Clear();
                txtCantidad.Text = 0.ToString();
            }


            private void btnSalir_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Desea SALIR?", "CONTROL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                {
                    if (dgvDetalle.CurrentCell.ColumnIndex == 4)
                    {
                        oPresupuesto.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                        dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
                        MessageBox.Show("El detalle a sido removido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Total();
                        dgvDetalle.Focus();
                    }
                }
            }
        }
    }


