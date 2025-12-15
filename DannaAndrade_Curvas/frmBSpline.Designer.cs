namespace DannaAndrade_Curvas
{
    partial class frmBSpline
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoUniforme;
        private System.Windows.Forms.RadioButton rdoClamped;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label labelInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.rdoClamped = new System.Windows.Forms.RadioButton();
            this.rdoUniforme = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(763, 689);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.rdoClamped);
            this.panel1.Controls.Add(this.rdoUniforme);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbGrado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(763, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 689);
            this.panel1.TabIndex = 1;
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(32, 394);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(368, 166);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Nota: Se requieren al menos (Grado + 1) puntos para ver la curva.";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(32, 290);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(368, 62);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar Lienzo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // rdoClamped
            // 
            this.rdoClamped.AutoSize = true;
            this.rdoClamped.Checked = true;
            this.rdoClamped.Location = new System.Drawing.Point(32, 213);
            this.rdoClamped.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdoClamped.Name = "rdoClamped";
            this.rdoClamped.Size = new System.Drawing.Size(248, 31);
            this.rdoClamped.TabIndex = 2;
            this.rdoClamped.TabStop = true;
            this.rdoClamped.Text = "No Uniforme (Clamp)";
            this.rdoClamped.UseVisualStyleBackColor = true;
            this.rdoClamped.CheckedChanged += new System.EventHandler(this.ForceRedraw);
            // 
            // rdoUniforme
            // 
            this.rdoUniforme.AutoSize = true;
            this.rdoUniforme.Location = new System.Drawing.Point(32, 166);
            this.rdoUniforme.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rdoUniforme.Name = "rdoUniforme";
            this.rdoUniforme.Size = new System.Drawing.Size(128, 31);
            this.rdoUniforme.TabIndex = 3;
            this.rdoUniforme.Text = "Uniforme";
            this.rdoUniforme.UseVisualStyleBackColor = true;
            this.rdoUniforme.CheckedChanged += new System.EventHandler(this.ForceRedraw);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grado de Curva:";
            // 
            // cmbGrado
            // 
            this.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Items.AddRange(new object[] {
            "Grado 2 (Cuadrática)",
            "Grado 3 (Cúbica)",
            "Grado 4"});
            this.cmbGrado.Location = new System.Drawing.Point(32, 84);
            this.cmbGrado.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(364, 35);
            this.cmbGrado.TabIndex = 0;
            this.cmbGrado.SelectedIndexChanged += new System.EventHandler(this.ForceRedraw);
            // 
            // frmBSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 689);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmBSpline";
            this.Text = "Curvas B-Spline";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}