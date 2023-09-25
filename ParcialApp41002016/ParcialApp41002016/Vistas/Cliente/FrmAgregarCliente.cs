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
            //lblCliente.Text = "Cliente: " + gestor.ObtenerId("SP_PROXIMO_CLIENTE");
            Loader();

        }

        private void Loader()
        {
            txtApellido.MaxLength = 50;
            txtNombre.MaxLength = 50;
            txtDomicilio.MaxLength = 50;
            txtAltura.MaxLength = 4;
            txtTelefono.MaxLength = 12;
            txtEmail.MaxLength = 50;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

            }
        }

        private bool ValidarDatos()
        {
            
            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El APELLIDO ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtApellido.Focus();
                return false;
            }
            else
            {
                for (int i = 1; i < txtApellido.Text.Length; i++)
                {
                    char c = txtApellido.Text[i];
                    if (Convert.ToInt32(c) <= 64 || Convert.ToInt32(c) >= 91 && Convert.ToInt32(c) <= 96 || Convert.ToInt32(c) >= 123)
                    {
                        MessageBox.Show("El APELLIDO ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtApellido.Focus();
                        return false;
                    }
                }
            }
            
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El NOMBRE ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return false;
            }
            else
            {
                for (int i = 0; i < txtNombre.Text.Length; i++)
                {
                    char c = txtNombre.Text[i];
                    if (Convert.ToInt32(c) <= 64 || Convert.ToInt32(c) >= 91 && Convert.ToInt32(c) <= 96 || Convert.ToInt32(c) >= 123)
                    {
                        MessageBox.Show("El APELLIDO ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtApellido.Focus();
                        return false;
                    }
                }
            }
            if(rbtFemenino.Checked == false && rbtMasculino.Checked == false && rbtIndefinido.Checked == false || rbtFemenino.Checked == true && rbtMasculino.Checked == true && rbtIndefinido.Checked == true) 
            {
                MessageBox.Show("Debe SELECCIONAR UNA SOLA OPCION EN CUANTO AL SEXO", "Control", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                lblSexo.Focus();
                return false;
            }
            if(!dtpFechaNac.Checked || dtpFechaNac.Value >= DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Debe ser MAYOR DE EDAD para ser registrado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                lblSexo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDomicilio.Text) || string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                MessageBox.Show("El DOMICILIO ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtDomicilio.Focus();
                return false;
            }
            else
            {
                for (int i = 0; i < txtDomicilio.Text.Length; i++)
                {
                    char c = txtDomicilio.Text[i];
                    if (Convert.ToInt32(c) <= 64 || Convert.ToInt32(c) >= 91 && Convert.ToInt32(c) <= 96 || Convert.ToInt32(c) >= 123)
                    {
                        MessageBox.Show("El DOMICILIO ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtDomicilio.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrEmpty(txtAltura.Text) || !int.TryParse(txtAltura.Text, out _) || string.IsNullOrWhiteSpace(txtAltura.Text))
            {
                MessageBox.Show("La ALTURA ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtAltura.Focus();
                return false;
            }
            else
            {
                foreach (char c in txtAltura.Text)
                {
                    if (Convert.ToInt32(c) <= 47 || Convert.ToInt32(c) >= 59)
                    {
                        MessageBox.Show("La ALTURA ingresada no es valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtAltura.Focus();
                        return false;
                    }

                }
            }
            if (!int.TryParse(txtTelefono.Text, out _) || string.IsNullOrEmpty(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El TELEFONO ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtTelefono.Focus();
                return false;
            }
            else
            {
                foreach (char c in txtTelefono.Text)
                {
                    if (Convert.ToInt32(c) <= 47 || Convert.ToInt32(c) >= 59)
                    {
                        MessageBox.Show("El TELEFONO ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtTelefono.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El E-MAIL ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return false;
            }
            else
            {
                int arroba = 0;
                int punto = 0;
                for(int i = 0; i < txtEmail.Text.Length; i++)
                {
                    if (txtEmail.Text[i] == 64)
                    {
                        arroba++;
                        for(int j = 0; j < txtEmail.Text.Length - (i + 1); j++)
                        {
                            if (txtEmail.Text[j] == 46)
                            {
                                punto++;
                            }
                        }
                    }
                }                
                if (arroba != 1 || punto == 0)
                {
                    MessageBox.Show("El E-MAIL ingresado no es valido", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEmail.Focus();
                    return false;
                }
            }            
            return true;

        }
    }
}

