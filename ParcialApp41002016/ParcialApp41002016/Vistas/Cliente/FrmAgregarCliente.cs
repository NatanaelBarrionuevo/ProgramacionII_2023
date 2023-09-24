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

namespace ParcialApp41002016.Vistas.Cliente
{
    public partial class FrmAgregarCliente : Form
    {
        private BDHelper gestor;
        private Clientes cliente;
        public FrmAgregarCliente()
        {
            InitializeComponent();
            gestor = new BDHelper();
            cliente = new Clientes();
            
        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            lblCliente.Text = "Cliente: " + gestor.ObtenreId("SP_PROXIMO_CLIENTE");
        }

       
    }
}
