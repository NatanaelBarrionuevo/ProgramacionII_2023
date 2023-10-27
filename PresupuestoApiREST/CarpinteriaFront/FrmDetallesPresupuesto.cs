using PresupuestoBack.Datos.DTOs;
using PresupuestoBack.Servicio;
using PresupuestosBack.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
{
    public partial class FrmDetallesPresupuesto : Form
    {
        private int presupuestoNro;
        private IServicio servicio;
        public FrmDetallesPresupuesto(int presupuestoNro)
        {
            InitializeComponent();
            this.presupuestoNro = presupuestoNro;
            servicio = new Servicio();
        }

        private void FrmDetallesPresupuesto_Load(object sender, EventArgs e)
        {
            //En el título de la ventana agregamos el número de presupuesto
            this.Text = this.Text + presupuestoNro.ToString();

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", presupuestoNro));

            PresupuestoDTO presupuesto = servicio.ObtenerDetalles(lst);

            txtCliente.Text = presupuesto.Cliente;
            txtFecha.Text = presupuesto.Fecha.ToShortDateString();
            txtTotal.Text = presupuesto.Total.ToString();
            txtDto.Text = presupuesto.Descuento.ToString();

            foreach (DetallePresupuestoDTO d in presupuesto.Detalles)
            {
                dgvDetalles.Rows.Add(new object[]
                {
                    d.NProducto,
                    d.Precio.ToString(),
                    d.Cantidad.ToString()
                });
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

   
}

