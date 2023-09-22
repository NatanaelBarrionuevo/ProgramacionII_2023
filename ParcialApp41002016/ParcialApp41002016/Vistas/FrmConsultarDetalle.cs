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
    public partial class FrmConsultarDetalle : Form
    {
        private int cod_presupuesto;
        private BDHelper gestor;
        private Presupuesto oPresupuesto;
        public FrmConsultarDetalle(int cod_presupuesto)
        {
            InitializeComponent();
            this.cod_presupuesto = cod_presupuesto;
            gestor = new BDHelper();
        }

        private void btbSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void FrmConsultarDetalle_Load(object sender, EventArgs e)
        {
            lblDetalle.Text = "Detalle del Presupuesto Nro: " + cod_presupuesto;
            
            MaestroDetalle();  
        }
        
        private void MaestroDetalle()
        {
            Parametros param = new Parametros("@cod_presupuesto", cod_presupuesto);
            List<Parametros> lista = new List<Parametros>() { param };
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_DETALLES_PRESUPUESTO", lista);

            string cliente = string.Empty;
            string fecha = string.Empty;
            string total = string.Empty;
            string descuento = string.Empty;
            foreach (DataRow fila in tabla.Rows)
            {//detalle
                int presupuesto = (int)fila.ItemArray[0];
                int detalle = (int)fila.ItemArray[1];
                string producto = fila.ItemArray[4].ToString();
                double precio = (double)fila.ItemArray[5];
                int cantidad = (int)fila.ItemArray[3];
                //maestro
                cliente = fila.ItemArray[6].ToString();
                fecha = fila.ItemArray[7].ToString();
                total = fila.ItemArray[7].ToString();
                descuento = fila.ItemArray[7].ToString();
                dgvDetalle.Rows.Add(new object[] {presupuesto, detalle, producto, precio, cantidad });
            }
            lblCliente.Text = cliente;
            lblFecha.Text = fecha;
            lblTotal.Text = total;
            lblDescuento.Text = descuento;
        }

    }
}
/*SELECT t.*, t2.n_producto, t2.precio, t3.cliente, t3.fecha, t3.total, t3.descuento
	FROM T_DETALLES_PRESUPUESTO t, T_PRODUCTOS t2, T_PRESUPUESTOS t3
	WHERE t.id_producto = t2.id_producto
	AND t.presupuesto_nro = t3.presupuesto_nro
	AND t.presupuesto_nro = @presupuesto_nro;*/


