using ABMLibros.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMLibros
{
    public partial class frmLibros : Form
    {
        LibroServicio oServicio;
        List<Libro> listaLibros;

        public frmLibros()
        {
            InitializeComponent();
            oServicio= new LibroServicio();
            listaLibros= new List<Libro>(); 
        }

        private void frmLibros_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo(cboAutor,"Autores");
            CargarLista();
        }

        private void CargarLista()
        {
            listaLibros.Clear();
            listaLibros = oServicio.TraerLibros();
            lstLibros.DataSource = listaLibros;
            lstLibros.SelectedIndex = 0;
        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dt = oServicio.TraerAutores();
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember= dt.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Habilitar(bool v)
        {
            txtCodigo.Enabled = v;
            txtPrecio.Enabled = v;
            txtTitulo.Enabled = v;
            cboAutor.Enabled = v;
            rbtDigital.Enabled = v;
            rbtImpreso.Enabled = v;
            dtpFechaPublicacion.Enabled = v;
            btnGrabar.Enabled = v;
            btnEditar.Enabled = !v;
            btnSalir.Enabled = !v;
            lstLibros.Enabled = !v;
        }

        private void lstLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCampos(listaLibros[lstLibros.SelectedIndex]);
        }

        private void CargarCampos(Libro l)
        {
            txtCodigo.Text = l.IdLibro.ToString();
            txtTitulo.Text = l.Titulo;
            txtPrecio.Text = l.Precio.ToString();
            cboAutor.SelectedValue = l.Autor;
            dtpFechaPublicacion.Value = l.FechaPublicacion;
            if (l.Formato == 1)
                rbtImpreso.Checked = true;
            else
                rbtDigital.Checked = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //validar datos

            Libro l = new Libro();
            l.IdLibro = Convert.ToInt32(txtCodigo.Text);
            l.Titulo = txtTitulo.Text;
            l.Autor = (int)cboAutor.SelectedValue;
            if (rbtImpreso.Checked)
                l.Formato = 1;
            else
                l.Formato = 2;
            l.Precio = Convert.ToDouble(txtPrecio.Text);
            l.FechaPublicacion = dtpFechaPublicacion.Value;

            if (oServicio.Modificar(l)>0)
            {
                MessageBox.Show("Se actualizó con éxito el libro!!!");
                CargarLista();
            }
            Habilitar(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            txtCodigo.Enabled = false;
            txtTitulo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLibros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Está seguro de abandonar la aplicación?", "SALIENDO"
                                , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
