namespace DannaAndrade_Curvas
{
    partial class frmBezier
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPolilinea;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkPolilinea = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
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
            this.picCanvas.Size = new System.Drawing.Size(679, 711);
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.chkPolilinea);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTipo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(679, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 711);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 354);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 208);
            this.label2.TabIndex = 0;
            this.label2.Text = "Instrucciones:\r\n- Click Izq: Poner punto\r\n- Arrastrar: Mover\r\n- Click Der: Borrar" +
    " último";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(32, 250);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(368, 62);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar / Reiniciar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // chkPolilinea
            // 
            this.chkPolilinea.AutoSize = true;
            this.chkPolilinea.Checked = true;
            this.chkPolilinea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolilinea.Location = new System.Drawing.Point(32, 166);
            this.chkPolilinea.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkPolilinea.Name = "chkPolilinea";
            this.chkPolilinea.Size = new System.Drawing.Size(160, 31);
            this.chkPolilinea.TabIndex = 2;
            this.chkPolilinea.Text = "Ver Polilínea";
            this.chkPolilinea.UseVisualStyleBackColor = true;
            this.chkPolilinea.CheckedChanged += new System.EventHandler(this.UpdateView);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Curva:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Lineal (2 pt)",
            "Cuadrática (3 pt)",
            "Cúbica (4 pt)",
            "Grado N (General)"});
            this.cmbTipo.Location = new System.Drawing.Point(32, 84);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(364, 35);
            this.cmbTipo.TabIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.ForceRedraw);
            // 
            // frmBezier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 711);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmBezier";
            this.Text = "Curvas Bézier";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}