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
            txtCliente.Text = string.Empty;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(-7);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Parametros param1 = new Parametros("@fecha_desde", dtpDesde.Value);
                Parametros param2 = new Parametros("@fecha_hasta", dtpHasta.Value);
                Parametros param3 = new Parametros("@cliente", txtCliente.Text.ToString());

                List<Parametros> lista = new List<Parametros>() {param1, param2, param3};
                
                DataTable tabla = gestor.ConsultarTabla("SP_CONSTULTAR_PRESUPUESTOS", lista);
                
                dgvDetalle.DataSource = lista;
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    int cod_presupuesto = Convert.ToInt32(tabla.Rows[i].ItemArray[0]);//Cod_presupuesto
                    string fechaAlta = tabla.Rows[i].ItemArray[1].ToString();//FechaAlta
                    string cliente = tabla.Rows[i].ItemArray[2].ToString();//Cliente
                    int descuento = Convert.ToInt32(tabla.Rows[i].ItemArray[3]);//Descuento
                    string fechaBaja = tabla.Rows[i].ItemArray[4].ToString();//FechaBaja
                    double total = (double)tabla.Rows[i].ItemArray[5];
                    dgvDetalle.Rows.Add(new object[] {cod_presupuesto, fechaAlta, cliente, descuento, fechaBaja, total, "Detalle"});
                    
                }
                
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
            if(dtpDesde.Checked && dtpHasta.Checked )
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

            if (dgvDetalle.CurrentCell.ColumnIndex == 6)
            {
                object []fila = new object[]{ dgvDetalle.CurrentRow.Clone()};
                new FrmConsultarDetalle(fila).ShowDialog();
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