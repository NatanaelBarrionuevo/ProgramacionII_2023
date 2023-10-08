using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdenRetiro.Entidades;
using OrdenRetiro.Datos;
using OrdenRetiro.Servicios.Interfaz;
using OrdenRetiro.Servicios.Implementacion;
using OrdenRetiro.Entidades.DTOs;

namespace OrdenRetiro
{
    public partial class FrmRegistrarOrden : Form
    {
        private IServicio servicio;
        private Orden orden;
        
        public FrmRegistrarOrden()
        {
            InitializeComponent();
            servicio = new Servicio();
            orden = new Orden();
        }

        private void FrmRegistrarOrden_Load(object sender, EventArgs e)
        {
            txtResponsable.MaxLength = 100;
            txtCantidad.MaxLength = 3;
            dtpFecha.Value = DateTime.Now.ToLocalTime();
            cboMaterial.Focus();
            CargarCombo();
        }

        private void CargarCombo()
        {            
            cboMaterial.DataSource = servicio.ObtenerMateriales();
            cboMaterial.ValueMember = "Codigo";
            cboMaterial.DisplayMember = "Nombre";
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Repite();
            if (Validar() && resultado == 0)
            {                
                DTOMaterial m = (DTOMaterial)cboMaterial.SelectedItem;                
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                Material oMaterial = new Material(m.Codigo, m.Nombre, m.Stock);
                DetalleOrden oDetalle = new DetalleOrden(oMaterial, cantidad);
                orden.AgregarDetalle(oDetalle);
                dgvDetalle.Rows.Add(new object[] { oMaterial.Codigo, oMaterial.Nombre, oMaterial.Cantidad, cantidad, "Quitar" });
            }
        }

        private bool Validar()
        {
            int aux = 0;
            if (string.IsNullOrEmpty(txtResponsable.Text) || string.IsNullOrWhiteSpace(txtResponsable.Text))
            {
                aux = 1;
            }
            else
            {
                foreach (char c in txtResponsable.Text)
                {
                    if (c <= 31 || c >= 33 && c <= 63 || c >= 91 && c <= 96 || c >= 123)
                    {
                        aux = 1;
                    }
                }
            }
            if (aux == 1)
            {
                MessageBox.Show("El Responsable ah sido cargado con un formato incorrecto, solo se permiten letras.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtCantidad.Focus();
                return false;
            }
            if (!int.TryParse(txtCantidad.Text, out _) || string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("Debe cargar al menos 1 cantidad.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtCantidad.Focus();
                return false;
            }
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un material.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cboMaterial.Focus();
                return false;
            }
            return true;
        }

        private int Repite()
        {
            int resultado = 0;
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.Cells["ColMaterial"].Value.ToString().Equals(cboMaterial.Text))
                {
                    if (MessageBox.Show("El producto ya se encuentra en el detalle, desea sumar las cantidades ?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        foreach (DetalleOrden detalle in orden.Detalle)
                        {
                            if (Convert.ToInt32(fila.Cells[0].Value) == detalle.Material.Codigo)
                            {
                                detalle.Cantidad += Convert.ToInt32(txtCantidad.Text);
                                fila.Cells["ColCantidad"].Value = Convert.ToInt32(fila.Cells["ColCantidad"].Value) + Convert.ToInt32(txtCantidad.Text);
                                resultado++;
                            }
                        }
                    }
                    else
                    {
                        resultado = -1;
                    }
                }
            }
            return resultado;
        }

        private void brnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Segur@ que desea SALIR?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                orden.Fecha = dtpFecha.Value;
                orden.Responsable = txtResponsable.Text.ToUpper();

                if (servicio.InsertarMaestroDetalle(orden) == 1)
                {
                    MessageBox.Show("La orden nro " + orden.CodOrden + " ha sido cargada exitosamente, que tenga un buen dia!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("La orden nro " + orden.CodOrden + " NO AH PODIDO SER CARGADA exitosamente, intente nuevamente o comuniquese con el adminsitrador.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    dgvDetalle.Focus();
                    btnAceptar.Focus();
                }
            }
        }

        private bool ValidarDetalle()
        {
            if (dgvDetalle.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar al menos un detalle.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                dgvDetalle.Focus();
                return false;
            }
            return true;
        }
        private void Limpiar()
        {
            txtCantidad.Clear();
            txtResponsable.Clear();
            cboMaterial.SelectedIndex = -1;
            dgvDetalle.Rows.Clear();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                if (MessageBox.Show("Desea QUITAR EL DETALLE NRO " + (Convert.ToInt32(dgvDetalle.CurrentRow.Index) + 1) + "?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {                    
                    orden.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                    dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
                }

            }
        }
    }
}
