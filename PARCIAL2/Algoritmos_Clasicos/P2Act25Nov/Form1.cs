using System;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Método auxiliar para cerrar cualquier formulario hijo abierto antes de abrir uno nuevo
        private void CerrarHijos()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        // ----------------------------------------------------
        // SECCIÓN DE LÍNEAS
        // ----------------------------------------------------
        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioLineas("DDA");
        }

        private void bresenhmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioLineas("BRESENHAM");
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioLineas("PUNTOMEDIO");
        }

        private void AbrirFormularioLineas(string algoritmo)
        {
            CerrarHijos();
            // Pasamos el nombre del algoritmo al constructor para que el hijo se configure solo
            frmLineas frm = new frmLineas(algoritmo);
            frm.MdiParent = this;
            frm.Show();
        }

        // ----------------------------------------------------
        // SECCIÓN DE CÍRCULOS
        // ----------------------------------------------------
        private void cirMetodo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCircunferencias("BRESENHAM");
        }

        private void método2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCircunferencias("ALGEBRAICO");
        }

        private void método3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCircunferencias("PARAMETRICO");
        }

        private void AbrirFormularioCircunferencias(string algoritmo)
        {
            CerrarHijos();
            frmCircunferencias frm = new frmCircunferencias(algoritmo);
            frm.MdiParent = this;
            frm.Show();
        }

        // ----------------------------------------------------
        // SECCIÓN DE RECORTES Y RELLENOS
        // ----------------------------------------------------
        private void figurasLinealesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarHijos();
            // Este formulario contiene todos los algoritmos de recorte y relleno juntos
            frmRecortes frm = new frmRecortes();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}