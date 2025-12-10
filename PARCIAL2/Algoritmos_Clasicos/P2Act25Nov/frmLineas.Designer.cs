namespace P2Act25Nov
{
    partial class frmLineas
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYf = new System.Windows.Forms.TextBox();
            this.txtXf = new System.Windows.Forms.TextBox();
            this.txtYo = new System.Windows.Forms.TextBox();
            this.txtXo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.pnlIzq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIzq
            // 
            this.pnlIzq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlIzq.Controls.Add(this.btnLimpiar);
            this.pnlIzq.Controls.Add(this.btnCalcular);
            this.pnlIzq.Controls.Add(this.label4);
            this.pnlIzq.Controls.Add(this.label3);
            this.pnlIzq.Controls.Add(this.label2);
            this.pnlIzq.Controls.Add(this.label1);
            this.pnlIzq.Controls.Add(this.txtYf);
            this.pnlIzq.Controls.Add(this.txtXf);
            this.pnlIzq.Controls.Add(this.txtYo);
            this.pnlIzq.Controls.Add(this.txtXo);
            this.pnlIzq.Controls.Add(this.lblTitulo);
            this.pnlIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzq.Location = new System.Drawing.Point(0, 0);
            this.pnlIzq.Name = "pnlIzq";
            this.pnlIzq.Size = new System.Drawing.Size(242, 463);
            this.pnlIzq.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(23, 340);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 41);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(25, 294);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(150, 40);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Dibujar";
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y1:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "X1:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y0:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "X0:";
            // 
            // txtYf
            // 
            this.txtYf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYf.Location = new System.Drawing.Point(92, 204);
            this.txtYf.Name = "txtYf";
            this.txtYf.Size = new System.Drawing.Size(100, 35);
            this.txtYf.TabIndex = 6;
            // 
            // txtXf
            // 
            this.txtXf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXf.Location = new System.Drawing.Point(92, 163);
            this.txtXf.Name = "txtXf";
            this.txtXf.Size = new System.Drawing.Size(100, 35);
            this.txtXf.TabIndex = 7;
            // 
            // txtYo
            // 
            this.txtYo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYo.Location = new System.Drawing.Point(92, 120);
            this.txtYo.Name = "txtYo";
            this.txtYo.Size = new System.Drawing.Size(100, 35);
            this.txtYo.TabIndex = 8;
            // 
            // txtXo
            // 
            this.txtXo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXo.Location = new System.Drawing.Point(92, 79);
            this.txtXo.Name = "txtXo";
            this.txtXo.Size = new System.Drawing.Size(100, 35);
            this.txtXo.TabIndex = 9;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 30);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Algoritmo";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(242, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(519, 463);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // frmLineas
            // 
            this.ClientSize = new System.Drawing.Size(761, 463);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.pnlIzq);
            this.Name = "frmLineas";
            this.pnlIzq.ResumeLayout(false);
            this.pnlIzq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlIzq;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtXo, txtYo, txtXf, txtYf;
        private System.Windows.Forms.Label label1, label2, label3, label4;
        private System.Windows.Forms.Button btnCalcular, btnLimpiar;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}