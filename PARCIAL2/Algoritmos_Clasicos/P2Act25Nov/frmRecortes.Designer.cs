namespace P2Act25Nov
{
    partial class frmRecortes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpVentana = new System.Windows.Forms.GroupBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.btnSetVentana = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.grpVentana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.grpVentana);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnRecortar);
            this.panel1.Controls.Add(this.cmbAlgoritmo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 497);
            this.panel1.TabIndex = 1;
            // 
            // grpVentana
            // 
            this.grpVentana.Controls.Add(this.txtX);
            this.grpVentana.Controls.Add(this.txtY);
            this.grpVentana.Controls.Add(this.txtW);
            this.grpVentana.Controls.Add(this.txtH);
            this.grpVentana.Controls.Add(this.btnSetVentana);
            this.grpVentana.Controls.Add(this.label2);
            this.grpVentana.Controls.Add(this.label3);
            this.grpVentana.Controls.Add(this.label4);
            this.grpVentana.Controls.Add(this.label5);
            this.grpVentana.Location = new System.Drawing.Point(12, 212);
            this.grpVentana.Name = "grpVentana";
            this.grpVentana.Size = new System.Drawing.Size(180, 208);
            this.grpVentana.TabIndex = 0;
            this.grpVentana.TabStop = false;
            this.grpVentana.Text = "Tamaño";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(62, 44);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(50, 35);
            this.txtX.TabIndex = 0;
            this.txtX.Text = "-10";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(122, 44);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(50, 35);
            this.txtY.TabIndex = 1;
            this.txtY.Text = "10";
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(62, 79);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(50, 35);
            this.txtW.TabIndex = 2;
            this.txtW.Text = "20";
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(122, 80);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(50, 35);
            this.txtH.TabIndex = 3;
            this.txtH.Text = "20";
            // 
            // btnSetVentana
            // 
            this.btnSetVentana.Location = new System.Drawing.Point(13, 132);
            this.btnSetVentana.Name = "btnSetVentana";
            this.btnSetVentana.Size = new System.Drawing.Size(150, 48);
            this.btnSetVentana.TabIndex = 4;
            this.btnSetVentana.Text = "Aplicar";
            this.btnSetVentana.Click += new System.EventHandler(this.btnSetVentana_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(102, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "W:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(102, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "H:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algoritmo:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 145);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 42);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(12, 99);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(180, 40);
            this.btnRecortar.TabIndex = 3;
            this.btnRecortar.Text = "Recortar (Animado)";
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 56);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(180, 35);
            this.cmbAlgoritmo.TabIndex = 4;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(200, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(653, 497);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // frmRecortes
            // 
            this.ClientSize = new System.Drawing.Size(853, 497);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Name = "frmRecortes";
            this.Text = "Recortes Animados";
            this.Load += new System.EventHandler(this.frmRecortes_Load);
            this.panel1.ResumeLayout(false);
            this.grpVentana.ResumeLayout(false);
            this.grpVentana.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpVentana;
        private System.Windows.Forms.TextBox txtX, txtY, txtW, txtH;
        private System.Windows.Forms.Button btnSetVentana;
        private System.Windows.Forms.Label label2, label3, label4, label5;
    }
}