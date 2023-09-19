namespace ParcialApp41002016
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPresupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modiificarPresupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPresupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.soporteToolStripMenuItem,
            this.presupuestosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem,
            this.cerrarToolStripMenuItem1});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "conectarbdToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cerrarToolStripMenuItem.Text = "Conectar BD";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.conectarbdToolStripMenuItem_Click);
            // 
            // soporteToolStripMenuItem
            // 
            this.soporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem});
            this.soporteToolStripMenuItem.Name = "soporteToolStripMenuItem";
            this.soporteToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.soporteToolStripMenuItem.Text = "Soporte";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(195, 34);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(189, 34);
            this.cargarToolStripMenuItem.Text = "Cargar";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(189, 34);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(189, 34);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(189, 34);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoPresupuestoToolStripMenuItem,
            this.cargarPresupuestosToolStripMenuItem,
            this.modiificarPresupuestosToolStripMenuItem,
            this.eliminarPresupuestosToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(134, 29);
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // nuevoPresupuestoToolStripMenuItem
            // 
            this.nuevoPresupuestoToolStripMenuItem.Name = "nuevoPresupuestoToolStripMenuItem";
            this.nuevoPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.nuevoPresupuestoToolStripMenuItem.Text = "Nuevo Presupuesto";
            this.nuevoPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.nuevoPresupuestoToolStripMenuItem_Click);
            // 
            // cargarPresupuestosToolStripMenuItem
            // 
            this.cargarPresupuestosToolStripMenuItem.Name = "cargarPresupuestosToolStripMenuItem";
            this.cargarPresupuestosToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.cargarPresupuestosToolStripMenuItem.Text = "Consultar Presupuestos";
            // 
            // modiificarPresupuestosToolStripMenuItem
            // 
            this.modiificarPresupuestosToolStripMenuItem.Name = "modiificarPresupuestosToolStripMenuItem";
            this.modiificarPresupuestosToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.modiificarPresupuestosToolStripMenuItem.Text = "Modificar Presupuestos";
            this.modiificarPresupuestosToolStripMenuItem.Click += new System.EventHandler(this.modiificarPresupuestosToolStripMenuItem_Click);
            // 
            // eliminarPresupuestosToolStripMenuItem
            // 
            this.eliminarPresupuestosToolStripMenuItem.Name = "eliminarPresupuestosToolStripMenuItem";
            this.eliminarPresupuestosToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.eliminarPresupuestosToolStripMenuItem.Text = "Eliminar Presupuestos";
            this.eliminarPresupuestosToolStripMenuItem.Click += new System.EventHandler(this.eliminarPresupuestosToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem1
            // 
            this.cerrarToolStripMenuItem1.Name = "cerrarToolStripMenuItem1";
            this.cerrarToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.cerrarToolStripMenuItem1.Text = "Cerrar";
            this.cerrarToolStripMenuItem1.Click += new System.EventHandler(this.cerrarToolStripMenuItem1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modiificarPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem1;
    }
}

