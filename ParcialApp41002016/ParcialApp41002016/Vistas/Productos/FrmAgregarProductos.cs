using ParcialApp41002016.Entidades;
using ParcialApp41002016.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialApp41002016.Vistas.Productos
{
    public partial class FrmAgregarProductos : Form
    {
        private Articulo articulo;
        private BDHelper gestor;
        private int nro;
        public FrmAgregarProductos()
        {
            InitializeComponent();
            articulo = new Articulo();
            gestor = new BDHelper();
        }

        private void FrmAgregarProductos_Load(object sender, EventArgs e)
        {
            nro = gestor.ObtenerId("SP_PROXIMO_PRODUCTO");
            lblProductoNro.Text = "Producto Numero: " + nro;
            txtNombre.MaxLength = 255;
            txtPrecio.MaxLength = 11;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta segur@ que desea DESEA SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes){ this.Dispose(); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                articulo.Cod_articulo = nro;
                articulo.Nombre = txtNombre.Text.ToString();
                articulo.Precio = Convert.ToDouble(txtPrecio.Text);
                articulo.Activo = true;

                if (gestor.AgregarProducto("SP_AGREGAR_PRODUCTO", articulo))
                {
                    MessageBox.Show("El producto fue agregado exitosamente, que tenga un buen dia!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("El producto NO AH PODIDO SER INGRESADO, porfavor intente nuevamente mas tarde o comuniquese con el administrador", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private bool ValidarDatos()
        {
            
            if (string.IsNullOrEmpty(txtNombre.Text) || txtNombre.Text.Length > 255)
            {
                MessageBox.Show("Asegurese de colocarle un NOMBRE con formato valido al PRODUCTO", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text) || !int.TryParse(txtPrecio.Text, out _) || txtPrecio.Text.Length > 11)
            {
                MessageBox.Show("Asegurese de colocarle un PRECIO con formato valido al PRODUCTO", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return false;
            }
            return true;
        }
        private void Limpiar()
        {
            lblProductoNro.Text = string.Empty;
            lblProductoNro.Text = "Producto Numero: " + nro;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }
    }
    
}
