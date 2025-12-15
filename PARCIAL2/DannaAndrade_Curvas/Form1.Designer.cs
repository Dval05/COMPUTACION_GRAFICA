namespace DannaAndrade_Curvas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bezierToolStripMenuItem,
            this.bSplineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bezierToolStripMenuItem
            // 
            this.bezierToolStripMenuItem.Name = "bezierToolStripMenuItem";
            this.bezierToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.bezierToolStripMenuItem.Text = "Curvas Bézier";
            this.bezierToolStripMenuItem.Click += new System.EventHandler(this.bezierToolStripMenuItem_Click);
            // 
            // bSplineToolStripMenuItem
            // 
            this.bSplineToolStripMenuItem.Name = "bSplineToolStripMenuItem";
            this.bSplineToolStripMenuItem.Size = new System.Drawing.Size(181, 34);
            this.bSplineToolStripMenuItem.Text = "Curvas B-Spline";
            this.bSplineToolStripMenuItem.Click += new System.EventHandler(this.bSplineToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "DannaAndrade_Curvas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem bezierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bSplineToolStripMenuItem;
    }
}