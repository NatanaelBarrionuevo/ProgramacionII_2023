﻿namespace ParcialApp41002016.Vistas
{
    partial class FrmModificarPresupuesto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.ColCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cboProductos = new System.Windows.Forms.ComboBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNuevoPresupuesto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 560);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 29);
            this.label6.TabIndex = 35;
            this.label6.Text = "Total$";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(714, 560);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(440, 26);
            this.txtTotal.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(574, 520);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 33;
            this.label5.Text = "Subtotal$";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(714, 520);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(440, 26);
            this.txtSubtotal.TabIndex = 32;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(464, 628);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 35);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(622, 628);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(112, 35);
            this.btnModificar.TabIndex = 30;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCod,
            this.ColProducto,
            this.ColPrecio,
            this.ColCantidad,
            this.ColAccion});
            this.dgvDetalle.Location = new System.Drawing.Point(46, 249);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.Size = new System.Drawing.Size(1110, 262);
            this.dgvDetalle.TabIndex = 29;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // ColCod
            // 
            this.ColCod.HeaderText = "Column1";
            this.ColCod.MinimumWidth = 8;
            this.ColCod.Name = "ColCod";
            this.ColCod.ReadOnly = true;
            this.ColCod.Visible = false;
            this.ColCod.Width = 150;
            // 
            // ColProducto
            // 
            this.ColProducto.HeaderText = "Producto";
            this.ColProducto.MinimumWidth = 8;
            this.ColProducto.Name = "ColProducto";
            this.ColProducto.ReadOnly = true;
            this.ColProducto.Width = 305;
            // 
            // ColPrecio
            // 
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.MinimumWidth = 8;
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            this.ColPrecio.Width = 150;
            // 
            // ColCantidad
            // 
            this.ColCantidad.FillWeight = 90F;
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.MinimumWidth = 8;
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            this.ColCantidad.Width = 70;
            // 
            // ColAccion
            // 
            this.ColAccion.HeaderText = "Acciones";
            this.ColAccion.MinimumWidth = 8;
            this.ColAccion.Name = "ColAccion";
            this.ColAccion.ReadOnly = true;
            this.ColAccion.Width = 150;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1044, 205);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 35);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(770, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(856, 206);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(148, 26);
            this.txtCantidad.TabIndex = 26;
            // 
            // cboProductos
            // 
            this.cboProductos.FormattingEnabled = true;
            this.cboProductos.Location = new System.Drawing.Point(46, 205);
            this.cboProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProductos.Name = "cboProductos";
            this.cboProductos.Size = new System.Drawing.Size(652, 28);
            this.cboProductos.TabIndex = 25;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(474, 151);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(148, 26);
            this.txtDescuento.TabIndex = 24;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(474, 115);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(530, 26);
            this.txtCliente.TabIndex = 23;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(474, 78);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(148, 26);
            this.txtFecha.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "%Descuento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Fecha:";
            // 
            // lblNuevoPresupuesto
            // 
            this.lblNuevoPresupuesto.AutoSize = true;
            this.lblNuevoPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoPresupuesto.Location = new System.Drawing.Point(40, 20);
            this.lblNuevoPresupuesto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevoPresupuesto.Name = "lblNuevoPresupuesto";
            this.lblNuevoPresupuesto.Size = new System.Drawing.Size(282, 33);
            this.lblNuevoPresupuesto.TabIndex = 18;
            this.lblNuevoPresupuesto.Text = "Prsupuesto Numero:";
            // 
            // FrmModificarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 657);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cboProductos);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNuevoPresupuesto);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1210, 713);
            this.MinimumSize = new System.Drawing.Size(1210, 713);
            this.Name = "FrmModificarPresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Presupuestos";
            this.Load += new System.EventHandler(this.FrmModificarPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn ColAccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cboProductos;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNuevoPresupuesto;
    }
}