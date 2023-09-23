using ParcialApp41002016.Entidades;
using ParcialApp41002016.Servicios;
using ParcialApp41002016.Vistas.Productos;
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
    public partial class FrmProductos : Form
    {
        private BDHelper gestor;
        private List<Articulo> articulo;
        public FrmProductos()
        {
            InitializeComponent();
            gestor = new BDHelper();
            articulo = new List<Articulo>();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

        }
        public void CargarProductos()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRODUCTOS");
            Articulo a;
            foreach (DataRow fila in tabla.Rows)
            {
                a = new Articulo();
                a.Cod_articulo = Convert.ToInt32(fila.ItemArray[0]);
                a.Nombre = fila.ItemArray[1].ToString();
                a.Precio = Convert.ToDouble(fila.ItemArray[2]);
                if (fila.ItemArray[3].ToString().Equals("S"))
                {
                    a.Activo = true;
                }

                if (a.Activo == true)
                {
                    dgvProductos.Rows.Add(new object[] { a.Cod_articulo, a.Nombre, a.Precio, "Modificar" });
                }
                articulo.Add(a);
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentCell.ColumnIndex == 3 && dgvProductos.CurrentRow != null)
            {
                int cod_producto = Convert.ToInt32(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[0].Value);
                new FrmModificarProducto(cod_producto).ShowDialog();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new FrmAgregarProductos().ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                if (MessageBox.Show("Esta seguro que desea ELIMINAR este PRODUCTO?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int cod_presupuesto = Convert.ToInt32(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[0].Value);
                    if (gestor.BajaProducto("SP_ELIMINAR_PRODUCTOS", cod_presupuesto))
                    {
                        MessageBox.Show("El producto ah sido eliminado, que tenga buen dia !", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dgvProductos.Rows.Clear();
                        CargarProductos();
                    }
                }
                else
                {
                    MessageBox.Show("El productos NO AH PODIDO SER ELIMINADO, porfavor intente nuevamente mas tarde o contacte con el adminsitrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cod_producto = Convert.ToInt32(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells[0].Value);
            new FrmModificarProducto(cod_producto).ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas segur@ que DESEAS SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
