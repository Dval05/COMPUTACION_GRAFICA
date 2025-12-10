namespace P2Act25Nov
{
    partial class Form1
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
            this.líneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cirMetodo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.método2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.método3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figurasLinealesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.líneasToolStripMenuItem,
            this.circunferenciaToolStripMenuItem,
            this.figurasLinealesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(2560, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // líneasToolStripMenuItem
            // 
            this.líneasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.bresenhmaToolStripMenuItem,
            this.puntoMedioToolStripMenuItem});
            this.líneasToolStripMenuItem.Name = "líneasToolStripMenuItem";
            this.líneasToolStripMenuItem.Size = new System.Drawing.Size(104, 37);
            this.líneasToolStripMenuItem.Text = "Líneas";
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.dDAToolStripMenuItem.Text = "DDA";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bresenhmaToolStripMenuItem
            // 
            this.bresenhmaToolStripMenuItem.Name = "bresenhmaToolStripMenuItem";
            this.bresenhmaToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.bresenhmaToolStripMenuItem.Text = "Bresenham";
            this.bresenhmaToolStripMenuItem.Click += new System.EventHandler(this.bresenhmaToolStripMenuItem_Click);
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.puntoMedioToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // circunferenciaToolStripMenuItem
            // 
            this.circunferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cirMetodo1ToolStripMenuItem,
            this.método2ToolStripMenuItem,
            this.método3ToolStripMenuItem});
            this.circunferenciaToolStripMenuItem.Name = "circunferenciaToolStripMenuItem";
            this.circunferenciaToolStripMenuItem.Size = new System.Drawing.Size(195, 37);
            this.circunferenciaToolStripMenuItem.Text = "Circunferencia";
            // 
            // cirMetodo1ToolStripMenuItem
            // 
            this.cirMetodo1ToolStripMenuItem.Name = "cirMetodo1ToolStripMenuItem";
            this.cirMetodo1ToolStripMenuItem.Size = new System.Drawing.Size(411, 42);
            this.cirMetodo1ToolStripMenuItem.Text = "Bresenham / Punto Medio";
            this.cirMetodo1ToolStripMenuItem.Click += new System.EventHandler(this.cirMetodo1ToolStripMenuItem_Click);
            // 
            // método2ToolStripMenuItem
            // 
            this.método2ToolStripMenuItem.Name = "método2ToolStripMenuItem";
            this.método2ToolStripMenuItem.Size = new System.Drawing.Size(411, 42);
            this.método2ToolStripMenuItem.Text = "Ecuación Algebraica";
            this.método2ToolStripMenuItem.Click += new System.EventHandler(this.método2ToolStripMenuItem_Click);
            // 
            // método3ToolStripMenuItem
            // 
            this.método3ToolStripMenuItem.Name = "método3ToolStripMenuItem";
            this.método3ToolStripMenuItem.Size = new System.Drawing.Size(411, 42);
            this.método3ToolStripMenuItem.Text = "Ecuación Paramétrica";
            this.método3ToolStripMenuItem.Click += new System.EventHandler(this.método3ToolStripMenuItem_Click);
            // 
            // figurasLinealesToolStripMenuItem
            // 
            this.figurasLinealesToolStripMenuItem.Name = "figurasLinealesToolStripMenuItem";
            this.figurasLinealesToolStripMenuItem.Size = new System.Drawing.Size(128, 37);
            this.figurasLinealesToolStripMenuItem.Text = "Recortes";
            this.figurasLinealesToolStripMenuItem.Click += new System.EventHandler(this.figurasLinealesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2560, 1570);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Algoritmos Gráficos - Danna Andrade";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem líneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circunferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cirMetodo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem método2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem método3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figurasLinealesToolStripMenuItem;
    }
}