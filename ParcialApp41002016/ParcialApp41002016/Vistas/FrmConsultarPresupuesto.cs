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
    public partial class FrmConsultarPresupuesto : Form
    {
        BDHelper gestor;
        Presupuesto oPresupuesto;
        public FrmConsultarPresupuesto()
        {
            InitializeComponent();
            gestor = new BDHelper();
        }

        private void FrmModificarPresupuesto_Load(object sender, EventArgs e)
        {
            txtCliente.MaxLength = 255;
            //txtCliente.Text = string.Empty;
            txtCliente.Text = "Consumidor Final";
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Parametros param1 = new Parametros("@fecha_desde", dtpDesde.Value);
                Parametros param2 = new Parametros("@fecha_hasta", dtpHasta.Value);
                Parametros param3 = new Parametros("@cliente", txtCliente.Text.ToString());

                List<Parametros> lista = new List<Parametros>() { param1, param2, param3 };


                DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRESUPUESTOS", lista);

                //dgvDetalle.DataSource = lista;
                foreach(DataRow fila in tabla.Rows)
                {
                    int cod_presupuesto = Convert.ToInt32(fila.ItemArray[0]);
                    string fechaAlta = fila.ItemArray[1].ToString();
                    string cliente = fila.ItemArray[2].ToString();
                    int descuento = Convert.ToInt32(fila.ItemArray[3]);
                    string fechaBaja = fila.ItemArray[4].ToString();
                    double total = Convert.ToDouble(fila.ItemArray[5]);
                    dgvDetalle.Rows.Add(new object[] { cod_presupuesto, fechaAlta, cliente, descuento, fechaBaja, total, "Ver Detalle" });
                }
                /*for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    int cod_presupuesto = Convert.ToInt32(tabla.Rows[i].ItemArray[0]);//Cod_presupuesto
                    string fechaAlta = tabla.Rows[i].ItemArray[1].ToString();//FechaAlta
                    string cliente = tabla.Rows[i].ItemArray[2].ToString();//Cliente
                    int descuento = Convert.ToInt32(tabla.Rows[i].ItemArray[3]);//Descuento
                    string fechaBaja = tabla.Rows[i].ItemArray[4].ToString();//FechaBaja
                    double total = (double)tabla.Rows[i].ItemArray[5];
                    

                }*/

            }

            /*CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRESUPUESTOS]
	@fecha_desde Datetime,
	@fecha_hasta Datetime,
	@cliente varchar(255)
AS
BEGIN
	SELECT * 
	FROM T_PRESUPUESTOS
	WHERE (@fecha_desde is null OR fecha >= @fecha_desde)
	AND (@fecha_hasta is null OR fecha <= @fecha_hasta)
	AND (@cliente is null OR cliente LIKE '%' + @cliente + '%')
	AND fecha_baja is null;
END*/
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtCliente.Text) || int.TryParse(txtCliente.Text, out _))
            {
                MessageBox.Show("Debe INGRESAR UN CLIENTE valido.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtCliente.Focus();
                return false;
            }
            if (!dtpDesde.Checked && !dtpHasta.Checked)
            {
                MessageBox.Show("Debe SELECCIONAR UNA FECHA.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                dtpHasta.Focus();
                dtpDesde.Focus();
                return false;
            }
            if (dtpDesde.Value > DateTime.Now || dtpHasta.Value > DateTime.Now)
            {
                MessageBox.Show("Debe SELECCIONAR UNA FECHA VALIDA.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                dtpHasta.Focus();
                dtpDesde.Focus();
                return false;
            }

            return true;
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDetalle.CurrentCell.ColumnIndex == 6 && dgvDetalle.CurrentRow != null)
            {
                int cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                new FrmConsultarDetalle(cod_presupuesto).ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod_presupuesto = 0;
            if (dgvDetalle.CurrentRow != null)
            {
                cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                if (MessageBox.Show("Esta seguro que desea ELIMINAR ESTE PRESUPUESTO?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (cod_presupuesto > 0 && gestor.BajaPresupuesto(cod_presupuesto))
                    {
                        MessageBox.Show("El Presupuesto a sido eliminado exitosamente, que tenga un buen dia !.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("El Presupuesto NO AH PODIDO SER ELIMINADO, disculpe las molestias. Intente nuevamente o consulte con el administrador.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }


            }



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea SALIR?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cod_presupuesto = 0;
            if (dgvDetalle.CurrentRow != null)
            {
                cod_presupuesto = Convert.ToInt32(dgvDetalle.Rows[dgvDetalle.CurrentRow.Index].Cells[0].Value);
                new FrmModificarPresupuesto(cod_presupuesto).ShowDialog();
                /*if (MessageBox.Show("Esta seguro que desea ELIMINAR ESTE PRESUPUESTO?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (cod_presupuesto > 0 && BDHelper.ObetenerInstancia().BajaPresupuesto(cod_presupuesto))
                    {
                        MessageBox.Show("El Presupuesto a sido eliminado exitosamente, que tenga un buen dia !.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("El Presupuesto NO AH PODIDO SER ELIMINADO, disculpe las molestias. Intente nuevamente o consulte con el administrador.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }*/


            }
        }
    }
}
/*
GO
CREATE PROCEDURE[dbo].[SP_MODIFICAR_MAESTRO]
@cliente varchar(255), 
@dto numeric(5,2),
@total numeric(8,2), 
@presupuesto_nro int
AS
BEGIN
UPDATE T_PRESUPUESTOS SET cliente = @cliente, descuento = @dto, total = @total

WHERE presupuesto_nro = @presupuesto_nro;

DELETE T_DETALLES_PRESUPUESTO

WHERE presupuesto_nro = @presupuesto_nro;
END */