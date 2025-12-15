using System;
using System.Windows.Forms;

namespace DannaAndrade_Curvas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void bezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmBezier frm = new frmBezier();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bSplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmBSpline frm = new frmBSpline();
            frm.MdiParent = this;
            frm.Show(); 
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}