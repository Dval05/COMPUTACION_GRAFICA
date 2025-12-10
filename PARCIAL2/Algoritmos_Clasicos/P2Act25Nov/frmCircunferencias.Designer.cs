namespace P2Act25Nov
{
    partial class frmCircunferencias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlIzq = new System.Windows.Forms.Panel();
            this.grpRelleno = new System.Windows.Forms.GroupBox();
            this.cmbRelleno = new System.Windows.Forms.ComboBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnActivarRelleno = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.pnlIzq.SuspendLayout();
            this.grpRelleno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzq
            // 
            this.pnlIzq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlIzq.Controls.Add(this.grpRelleno);
            this.pnlIzq.Controls.Add(this.btnLimpiar);
            this.pnlIzq.Controls.Add(this.btnDibujar);
            this.pnlIzq.Controls.Add(this.txtRadio);
            this.pnlIzq.Controls.Add(this.label1);
            this.pnlIzq.Controls.Add(this.lblTitulo);
            this.pnlIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzq.Location = new System.Drawing.Point(0, 0);
            this.pnlIzq.Name = "pnlIzq";
            this.pnlIzq.Size = new System.Drawing.Size(234, 468);
            this.pnlIzq.TabIndex = 1;
            // 
            // grpRelleno
            // 
            this.grpRelleno.Controls.Add(this.cmbRelleno);
            this.grpRelleno.Controls.Add(this.btnColor);
            this.grpRelleno.Controls.Add(this.btnActivarRelleno);
            this.grpRelleno.Location = new System.Drawing.Point(10, 210);
            this.grpRelleno.Name = "grpRelleno";
            this.grpRelleno.Size = new System.Drawing.Size(218, 156);
            this.grpRelleno.TabIndex = 0;
            this.grpRelleno.TabStop = false;
            this.grpRelleno.Text = "Relleno";
            // 
            // cmbRelleno
            // 
            this.cmbRelleno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRelleno.Location = new System.Drawing.Point(10, 25);
            this.cmbRelleno.Name = "cmbRelleno";
            this.cmbRelleno.Size = new System.Drawing.Size(202, 28);
            this.cmbRelleno.TabIndex = 0;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Yellow;
            this.btnColor.Location = new System.Drawing.Point(9, 63);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(202, 34);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "Color...";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnActivarRelleno
            // 
            this.btnActivarRelleno.Location = new System.Drawing.Point(10, 104);
            this.btnActivarRelleno.Name = "btnActivarRelleno";
            this.btnActivarRelleno.Size = new System.Drawing.Size(202, 40);
            this.btnActivarRelleno.TabIndex = 2;
            this.btnActivarRelleno.Text = "Modo Relleno (Click)";
            this.btnActivarRelleno.Click += new System.EventHandler(this.btnActivarRelleno_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(20, 160);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 30);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(20, 119);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(180, 35);
            this.btnDibujar.TabIndex = 2;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(100, 70);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 26);
            this.txtRadio.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Radio:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 40);
            this.lblTitulo.TabIndex = 5;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(234, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(578, 468);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // frmCircunferencias
            // 
            this.ClientSize = new System.Drawing.Size(812, 468);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.pnlIzq);
            this.Name = "frmCircunferencias";
            this.Text = "Trazado y Relleno de Círculos";
            this.pnlIzq.ResumeLayout(false);
            this.pnlIzq.PerformLayout();
            this.grpRelleno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlIzq;
        private System.Windows.Forms.Label lblTitulo, label1;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Button btnDibujar, btnLimpiar;
        private System.Windows.Forms.GroupBox grpRelleno;
        private System.Windows.Forms.ComboBox cmbRelleno;
        private System.Windows.Forms.Button btnColor, btnActivarRelleno;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}