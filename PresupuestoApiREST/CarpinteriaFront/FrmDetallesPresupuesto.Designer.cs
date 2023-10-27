namespace CarpinteriaApp.formularios
{
    partial class FrmDetallesPresupuesto
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
            dgvDetalles = new DataGridView();
            colProd = new DataGridViewTextBoxColumn();
            precioCol = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            txtTotal = new TextBox();
            label5 = new Label();
            txtCliente = new TextBox();
            label3 = new Label();
            txtFecha = new TextBox();
            label2 = new Label();
            txtDto = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AllowUserToResizeColumns = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { colProd, precioCol, colCantidad });
            dgvDetalles.Location = new Point(3, 275);
            dgvDetalles.Margin = new Padding(5, 6, 5, 6);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 62;
            dgvDetalles.Size = new Size(940, 296);
            dgvDetalles.TabIndex = 10;
            // 
            // colProd
            // 
            colProd.HeaderText = "Producto";
            colProd.MinimumWidth = 8;
            colProd.Name = "colProd";
            colProd.ReadOnly = true;
            colProd.Width = 220;
            // 
            // precioCol
            // 
            precioCol.HeaderText = "Precio";
            precioCol.MinimumWidth = 8;
            precioCol.Name = "precioCol";
            precioCol.ReadOnly = true;
            precioCol.Width = 150;
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 8;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 150;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(395, 602);
            btnCerrar.Margin = new Padding(5, 6, 5, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(143, 44);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Location = new Point(170, 194);
            txtTotal.Margin = new Padding(5, 6, 5, 6);
            txtTotal.MaxLength = 2;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(264, 31);
            txtTotal.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(115, 200);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(53, 25);
            label5.TabIndex = 17;
            label5.Text = "Total:";
            // 
            // txtCliente
            // 
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(170, 119);
            txtCliente.Margin = new Padding(5, 6, 5, 6);
            txtCliente.MaxLength = 100;
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(771, 31);
            txtCliente.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 125);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 16;
            label3.Text = "Cliente:";
            // 
            // txtFecha
            // 
            txtFecha.Enabled = false;
            txtFecha.Location = new Point(170, 50);
            txtFecha.Margin = new Padding(5, 6, 5, 6);
            txtFecha.MaxLength = 10;
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(264, 31);
            txtFecha.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 56);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 25);
            label2.TabIndex = 14;
            label2.Text = "Fecha:";
            // 
            // txtDto
            // 
            txtDto.Enabled = false;
            txtDto.Location = new Point(512, 194);
            txtDto.Margin = new Padding(5, 6, 5, 6);
            txtDto.MaxLength = 2;
            txtDto.Name = "txtDto";
            txtDto.Size = new Size(264, 31);
            txtDto.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 200);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 19;
            label1.Text = "% Dto.:";
            // 
            // FrmDetallesPresupuesto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 669);
            Controls.Add(txtDto);
            Controls.Add(label1);
            Controls.Add(txtTotal);
            Controls.Add(label5);
            Controls.Add(txtCliente);
            Controls.Add(label3);
            Controls.Add(txtFecha);
            Controls.Add(label2);
            Controls.Add(btnCerrar);
            Controls.Add(dgvDetalles);
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FrmDetallesPresupuesto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Presupuesto N°";
            Load += FrmDetallesPresupuesto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetalles;
        private Button btnCerrar;
        private TextBox txtTotal;
        private Label label5;
        private TextBox txtCliente;
        private Label label3;
        private TextBox txtFecha;
        private Label label2;
        private DataGridViewTextBoxColumn colProd;
        private DataGridViewTextBoxColumn precioCol;
        private DataGridViewTextBoxColumn colCantidad;
        private TextBox txtDto;
        private Label label1;
    }
}