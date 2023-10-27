using CarpinteriaBack.Datos.DTOs;
using PresupuestoBack.Servicio;
using PresupuestosBack.Datos;


namespace CarpinteriaApp.formularios
{
    public partial class FrmConsultarPresupuestos : Form
    {
        private IServicio servicio;
        public FrmConsultarPresupuestos()
        {
            InitializeComponent();
            servicio = new Servicio();
        }

        private void Frm_Consultar_Presupuestos_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(7);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            List<Parametro> aux = new List<Parametro>();
            aux.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            aux.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            aux.Add(new Parametro("@cliente", txtCliente.Text));

            List<ConsultarPresupuestoDTO> lst = servicio.ObtenerPresupuestos(aux);

            dgvPresupuestos.Rows.Clear();
            //DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);//NO HACEMOS MAS NEW, A LA PROPIA CALSE HELPERDB LE PEDIMOS UNA INSTANCIA Y A ESA INSTANCIA EL COMPORTAMIENTO CONSULTAR

            foreach (ConsultarPresupuestoDTO item in lst)
            {
                dgvPresupuestos.Rows.Add(new object[] {
                    item.Nro,
                    item.Fecha,
                    item.Cliente,
                    item.Total});
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresupuestos.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                new FrmDetallesPresupuesto(nro).ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea quitar el presupuesto seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvPresupuestos.CurrentRow != null)
                {
                    int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                    
                    bool afectadas = servicio.EliminarPresupuesto(nro);
                    if (afectadas)
                    {
                        MessageBox.Show("El presupuesto se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("El presupuesto NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPresupuestos_Click(object sender, EventArgs e)
        {
            DataGridViewRow actual = dgvPresupuestos.CurrentRow;
            if (actual != null)
            {
                btnBorrar.Enabled = BtnEditar.Enabled = true;

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
            new FrmModificarPresupuesto(nro).ShowDialog();
            this.btnConsultar_Click(null, null);
        }
    }
}
//TUNING DE CONSULTAS, OPTIMIZACION, PLAN DE EJECUCION
//TRIGGER
//ADMINISTRACION DE BD 
