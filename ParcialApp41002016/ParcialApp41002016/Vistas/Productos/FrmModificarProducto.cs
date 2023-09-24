using System;
using ParcialApp41002016.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcialApp41002016.Servicios;
using System.Security.Cryptography.X509Certificates;

namespace ParcialApp41002016.Vistas.Productos
{

    public partial class FrmModificarProducto : Form
    {
        private Articulo a;
        private List<Articulo> articulos;
        private BDHelper gestor;
        private int cod_producto;
        private bool aux;
        public FrmModificarProducto(int cod_producto)
        {
            InitializeComponent();
            this.cod_producto = cod_producto;
            a = new Articulo();
            gestor = new BDHelper();
            articulos = new List<Articulo>();   
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas segur@ que DESEAS SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void FrmModificarProducto_Load(object sender, EventArgs e)
        {
            Loader();

            DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRODUCTOS");

            foreach (DataRow row in tabla.Rows)
            {
                if(Convert.ToInt32(row.ItemArray[0]) == cod_producto)
                {
                    txtNombre.Text = row.ItemArray[1].ToString(); ;
                    txtPrecio.Text = row.ItemArray[2].ToString(); ;
                    
                }                
            }

            
        }        
        private void Loader()
        {
            lblProductoNro.Text = "Producto Numero: " + cod_producto;
            txtNombre.MaxLength = 255;
            txtPrecio.MaxLength = 10;
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                a.Cod_articulo = cod_producto;
                a.Nombre = txtNombre.Text;
                a.Precio = Convert.ToDouble(txtPrecio.Text);
                a.Activo = true;                
                
                if (gestor.ModificarProducto("SP_MODIFICAR_PRODUCTOS", a))
                {
                    MessageBox.Show("El producto ah sido modificado exitosamente, que tenga un buen dia", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                    this.Dispose();

                    
                }
                else
                {
                    MessageBox.Show("El PRODUCTO NO AH PODIDO SER MODIFICADO, porfavor intente de nuevo mas tarde o comuniquese con el administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    btnModificar.Focus();
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
            if (string.IsNullOrEmpty(txtPrecio.Text) || !double.TryParse(txtPrecio.Text, out _) || txtPrecio.Text.Length > 11)
            {
                MessageBox.Show("Asegurese de colocarle un PRECIO con formato valido al PRODUCTO", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return false;
            }
            
            return true;
        }
    }
}
