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
    public partial class FrmEliminarPresupuesto : Form
    {
        BDHelper gestor;
        Presupuesto oPresupuesto;
        public FrmEliminarPresupuesto()
        {
            InitializeComponent();
            gestor = new BDHelper();
            
        }

        private void FrmEliminarPresupuesto_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            txtPresupuestoNumero.Text = 0.ToString();
            txtFecBaja.Text = DateTime.Now.ToShortDateString();
            txtPresupuestoNumero.Focus();

        }
        
        private void Habilitar(bool x)
        {
            txtFecAlta.Enabled = x;
            txtFecBaja.Enabled = x;
            txtCliente.Enabled = x;
            txtDescuento.Enabled = x;
            txtTotal.Enabled = x;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

                if (MessageBox.Show("Esta seguro que desea dar de baja a este presupuesto?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gestor.BajaPresupuesto(Convert.ToInt32(txtPresupuestoNumero.Text));
                    Limpiar();
                }
            }
        }

        private void Limpiar()
        {
            txtFecAlta.Clear();
            txtFecBaja.Clear();
            txtCliente.Clear();
            txtDescuento.Clear();
            txtTotal.Clear();
            dgvDetalle.Rows.Clear();
            txtPresupuestoNumero.Clear();
        }
        private bool Validar()
        {
            if(string.IsNullOrEmpty(txtPresupuestoNumero.Text) || int.TryParse(txtPresupuestoNumero.Text, out _) || Convert.ToInt32(txtPresupuestoNumero.Text) <= 0)
            {
                MessageBox.Show("No se a insertado un NUMERO de PRESUPUESTO VALIDO.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtPresupuestoNumero.Focus();
                return false;
            }
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            new FrmModificarPresupuesto().ShowDialog();
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                Parametros param = new Parametros("@presupuesto_nro", Convert.ToInt32(txtPresupuestoNumero.Text));
                List<Parametros> lista = new List<Parametros>();
                lista.Add(param);

                DataTable tabla = gestor.ConsultarTabla("SP_CONSULTAR_DETALLES_PRESUPUESTO", lista);
                Articulo articulo;
                DetallePresupuesto detalle;

                double totales = 0;
                int descuentos = 0;
                string fecha = string.Empty;
                string cl = string.Empty;
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    int cod_presupuesto = (int)tabla.Rows[i].ItemArray[0];//Cod_presupuesto
                    int cod_detalle = (int)tabla.Rows[i].ItemArray[1];//Cod_detalle
                    int cod_articulo = (int)tabla.Rows[i].ItemArray[2];//Cod_producto
                    int cantidad = (int)tabla.Rows[i].ItemArray[3];//Cantidad
                    string nombre_prod = tabla.Rows[i].ItemArray[4].ToString();//Producto
                    string cliente = tabla.Rows[i].ItemArray[5].ToString();//Cliente
                    string fec_alta = tabla.Rows[i].ItemArray[6].ToString();//Fec_alta
                    double total = (double)tabla.Rows[i].ItemArray[7];//Total
                    int descuento = (int)tabla.Rows[i].ItemArray[8];//Descuento

                    

                    DataTable auxiliar = gestor.Consultar("SP_CONSULTAR_PRODUCTOS");
                    double pre_unitario = 0;
                    for (int j = 0; j < auxiliar.Rows.Count; j++)
                    {
                        if ((int)auxiliar.Rows[j].ItemArray[0] == cod_articulo)
                        {
                            pre_unitario = (double)auxiliar.Rows[j].ItemArray[3];
                        }
                    }

                    articulo = new Articulo(cod_articulo, nombre_prod, pre_unitario);
                    detalle = new DetallePresupuesto(cod_presupuesto, articulo, cantidad);

                    dgvDetalle.Rows.Add(new object[] { cod_articulo, nombre_prod, detalle.PrecioVenta(), cantidad });
                    totales += total;
                    descuentos += descuento;
                    fecha = fec_alta;
                    cl = cliente;
                }
               
                txtTotal.Text = totales.ToString();
                txtDescuento.Text = descuentos.ToString();
                txtFecAlta.Text = fecha;
                txtCliente.Text = cl;
               
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si conoce el id del presupuesto que desea borrar, ingreselo y haga click en seleccionar. \nSi no conoce el id, haga clic en consultar para buscar el preupuesto.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
