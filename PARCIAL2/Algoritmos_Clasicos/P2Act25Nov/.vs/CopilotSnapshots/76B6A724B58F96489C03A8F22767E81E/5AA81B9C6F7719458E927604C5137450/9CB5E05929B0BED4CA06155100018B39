using System;
using System.Drawing;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public partial class frmLineas : Form
    {
        private string algoritmo;
        // Instancia de la clase lógica que creamos antes
        private CAlgoritmosLineas motor = new CAlgoritmosLineas();

        public frmLineas(string alg)
        {
            InitializeComponent();
            algoritmo = alg;
            this.Text = "Algoritmo de Línea: " + algoritmo;
            lblTitulo.Text = algoritmo;
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtXo.Text) || string.IsNullOrWhiteSpace(txtYo.Text) ||
                string.IsNullOrWhiteSpace(txtXf.Text) || string.IsNullOrWhiteSpace(txtYf.Text))
            {
                MessageBox.Show("Por favor, ingrese todos los valores de coordenadas.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que X0 sea un número entero
            if (!int.TryParse(txtXo.Text, out int x0))
            {
                MessageBox.Show("El valor de X₀ debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXo.SelectAll();
                txtXo.Focus();
                return;
            }

            // Validar que Y0 sea un número entero
            if (!int.TryParse(txtYo.Text, out int y0))
            {
                MessageBox.Show("El valor de Y₀ debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYo.SelectAll();
                txtYo.Focus();
                return;
            }

            // Validar que X1 sea un número entero
            if (!int.TryParse(txtXf.Text, out int x1))
            {
                MessageBox.Show("El valor de Xf debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXf.SelectAll();
                txtXf.Focus();
                return;
            }

            // Validar que Y1 sea un número entero
            if (!int.TryParse(txtYf.Text, out int y1))
            {
                MessageBox.Show("El valor de Yf debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYf.SelectAll();
                txtYf.Focus();
                return;
            }

            try
            {
                if (picCanvas.Image == null)
                    picCanvas.Image = new Bitmap(picCanvas.Width, picCanvas.Height);

                using (Graphics g = Graphics.FromImage(picCanvas.Image))
                {
                    g.Clear(Color.White);
                    // Dibujar Ejes
                    g.DrawLine(Pens.LightGray, picCanvas.Width / 2, 0, picCanvas.Width / 2, picCanvas.Height);
                    g.DrawLine(Pens.LightGray, 0, picCanvas.Height / 2, picCanvas.Width, picCanvas.Height / 2);
                }
                picCanvas.Refresh();

                switch (algoritmo)
                {
                    case "DDA":
                        await motor.DibujarDDA(picCanvas, x0, y0, x1, y1);
                        break;
                    case "BRESENHAM":
                        await motor.DibujarBresenham(picCanvas, x0, y0, x1, y1);
                        break;
                    case "PUNTOMEDIO":
                        await motor.DibujarPuntoMedio(picCanvas, x0, y0, x1, y1);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar la línea:\n{ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtXo.Clear(); txtYo.Clear(); txtXf.Clear(); txtYf.Clear();
            if (picCanvas.Image != null)
            {
                using (Graphics g = Graphics.FromImage(picCanvas.Image)) g.Clear(Color.White);
                picCanvas.Refresh();
            }
        }
    }
}