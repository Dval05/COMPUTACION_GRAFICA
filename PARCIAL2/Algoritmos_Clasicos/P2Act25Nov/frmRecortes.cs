using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public partial class frmRecortes : Form
    {
        private const int PIXEL_SIZE = 15;
        private Bitmap mainBitmap;

        private CRecorteLineas recorteLineas = new CRecorteLineas();
        private CRecortePoligonos recortePoligonos = new CRecortePoligonos();

        private List<Point> puntos = new List<Point>();
        private Rectangle ventanaLogica = new Rectangle(-10, 10, 20, 20); // X, Y(Top), W, H

        public frmRecortes()
        {
            InitializeComponent();
            picCanvas.Paint += PicCanvas_Paint;

            cmbAlgoritmo.Items.Add("Línea: Cohen-Sutherland");
            cmbAlgoritmo.Items.Add("Línea: Liang-Barsky");
            cmbAlgoritmo.Items.Add("Línea: Punto Medio");
            cmbAlgoritmo.Items.Add("Polígono: Sutherland-Hodgman");
            cmbAlgoritmo.Items.Add("Polígono: Weiler-Atherton");
            cmbAlgoritmo.Items.Add("Polígono: Rectangular");
            cmbAlgoritmo.SelectedIndex = 0;
        }

        // --- FUNCIONES DE COORDENADAS (CLAVE PARA ALINEACIÓN) ---

        // Calcula el centro de la pantalla BASADO EN LA GRILLA, no en pixeles
        private void GetCenters(out int cxLogico, out int cyLogico)
        {
            int gridW = picCanvas.Width / PIXEL_SIZE;
            int gridH = picCanvas.Height / PIXEL_SIZE;
            cxLogico = gridW / 2;
            cyLogico = gridH / 2;
        }

        // Convierte Logica -> Pantalla (Pixel exacto para dibujar líneas)
        private Point ToScreen(int x, int y)
        {
            GetCenters(out int cx, out int cy);
            int sx = (cx + x) * PIXEL_SIZE + (PIXEL_SIZE / 2); // +Half para centrar en el cuadro
            int sy = (cy - y) * PIXEL_SIZE + (PIXEL_SIZE / 2);
            return new Point(sx, sy);
        }

        // Convierte Logica -> Pantalla (Esquina superior izquierda para rectángulos/rellenos)
        private Point ToScreenBox(int x, int y)
        {
            GetCenters(out int cx, out int cy);
            int sx = (cx + x) * PIXEL_SIZE;
            int sy = (cy - y) * PIXEL_SIZE; // Nota: Si y es positivo, sube (screen disminuye)
            return new Point(sx, sy);
        }

        // --- INICIALIZACIÓN ---

        private void InicializarCanvas()
        {
            if (picCanvas.Width == 0) return;
            mainBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);

            using (Graphics g = Graphics.FromImage(mainBitmap))
            {
                g.Clear(Color.White);
            }
            picCanvas.Image = mainBitmap;
            picCanvas.Refresh();
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetCenters(out int cx, out int cy);

            // 1. Grid
            Pen pGrid = new Pen(Color.FromArgb(240, 240, 240));
            for (int i = 0; i < picCanvas.Width; i += PIXEL_SIZE) g.DrawLine(pGrid, i, 0, i, picCanvas.Height);
            for (int j = 0; j < picCanvas.Height; j += PIXEL_SIZE) g.DrawLine(pGrid, 0, j, picCanvas.Width, j);

            // 2. Ejes (Alineados a la grilla)
            Pen axis = new Pen(Color.Black, 1);
            int screenCx = cx * PIXEL_SIZE;
            int screenCy = cy * PIXEL_SIZE;

            // Dibujar líneas de eje en el borde de la celda central
            g.DrawLine(axis, screenCx, 0, screenCx, picCanvas.Height);
            g.DrawLine(axis, 0, screenCy, picCanvas.Width, screenCy);

            // 3. Ventana Roja (Alineada perfectamente)
            // Lógica: Top-Left (x, y) -> Convertir a Screen -> Ancho/Alto escalados
            Point pWin = ToScreenBox(ventanaLogica.X, ventanaLogica.Y);
            // Ojo: En ToScreenBox, Y positivo sube. Pero el rectángulo se dibuja hacia abajo (Height).
            // Si ventanaLogica.Y es 10, ToScreenBox devuelve el pixel superior. 

            int ww = ventanaLogica.Width * PIXEL_SIZE;
            int wh = ventanaLogica.Height * PIXEL_SIZE;

            using (Pen wPen = new Pen(Color.Red, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                g.DrawRectangle(wPen, pWin.X, pWin.Y, ww, wh);
            }
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            GetCenters(out int cx, out int cy);

            // Pantalla -> Lógica
            int logX = (e.X / PIXEL_SIZE) - cx;
            int logY = cy - (e.Y / PIXEL_SIZE); // Y invertido

            puntos.Add(new Point(logX, logY));

            using (Graphics g = Graphics.FromImage(mainBitmap))
            {
                // Dibujar puntito negro
                Point screenP = ToScreen(logX, logY);
                g.FillEllipse(Brushes.Black, screenP.X - 3, screenP.Y - 3, 6, 6);

                int op = cmbAlgoritmo.SelectedIndex;
                // Dibujar línea guía "Lápiz" (gris)
                if (op <= 2 && puntos.Count % 2 == 0) // Líneas
                {
                    DibujarLineaGris(g, puntos[puntos.Count - 2], puntos[puntos.Count - 1]);
                }
                else if (op > 2 && puntos.Count > 1) // Polígonos
                {
                    DibujarLineaGris(g, puntos[puntos.Count - 2], puntos[puntos.Count - 1]);
                }
            }
            picCanvas.Refresh();
        }

        private void DibujarLineaGris(Graphics g, Point p1, Point p2)
        {
            Point s1 = ToScreen(p1.X, p1.Y);
            Point s2 = ToScreen(p2.X, p2.Y);

            using (Pen grayPen = new Pen(Color.Gray, 2))
            {
                g.DrawLine(grayPen, s1, s2);
            }
        }

        private async void btnRecortar_Click(object sender, EventArgs e)
        {
            if (puntos.Count < 2) return;

            InicializarCanvas(); // Limpiar líneas grises

            // Configurar límites para las clases
            // Y-Top matemático es ventanaLogica.Y
            // Y-Bottom matemático es ventanaLogica.Y - Height
            int xLeft = ventanaLogica.X;
            int xRight = ventanaLogica.X + ventanaLogica.Width;
            int yTop = ventanaLogica.Y;
            int yBottom = ventanaLogica.Y - ventanaLogica.Height;

            recorteLineas.SetVentana(xLeft, xRight, yBottom, yTop);

            using (Graphics g = Graphics.FromImage(mainBitmap))
            {
                int op = cmbAlgoritmo.SelectedIndex;

                if (op <= 2) // LÍNEAS
                {
                    for (int i = 0; i < puntos.Count - 1; i += 2)
                    {
                        Point p1 = puntos[i];
                        Point p2 = puntos[i + 1];
                        if (op == 0) await recorteLineas.EjecutarCohenSutherland(g, picCanvas, p1, p2);
                        else if (op == 1) await recorteLineas.EjecutarLiangBarsky(g, picCanvas, p1, p2);
                        else await recorteLineas.EjecutarPuntoMedio(g, picCanvas, p1, p2);
                    }
                }
                else // POLÍGONOS
                {
                    if (puntos.Count < 3) return;

                    if (op == 3) await recortePoligonos.EjecutarSutherlandHodgman(g, picCanvas, puntos, xLeft, xRight, yBottom, yTop);
                    else if (op == 4) await recortePoligonos.EjecutarWeilerAtherton(g, picCanvas, puntos, xLeft, xRight, yBottom, yTop);
                    else if (op == 5) await recortePoligonos.EjecutarRecorteRectangular(g, picCanvas, puntos, xLeft, xRight, yBottom, yTop);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntos.Clear();
            InicializarCanvas();
        }

        private void frmRecortes_Load(object sender, EventArgs e)
        {
            InicializarCanvas();
        }

        private void btnSetVentana_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtY.Text) ||
                string.IsNullOrWhiteSpace(txtW.Text) || string.IsNullOrWhiteSpace(txtH.Text))
            {
                MessageBox.Show("Por favor, ingrese todos los valores para la ventana de recorte.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que X sea un número entero
            if (!int.TryParse(txtX.Text, out int x))
            {
                MessageBox.Show("El valor de X debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtX.SelectAll();
                txtX.Focus();
                return;
            }

            // Validar que Y sea un número entero
            if (!int.TryParse(txtY.Text, out int y))
            {
                MessageBox.Show("El valor de Y debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtY.SelectAll();
                txtY.Focus();
                return;
            }

            // Validar que Width sea un número entero
            if (!int.TryParse(txtW.Text, out int w))
            {
                MessageBox.Show("El ancho (Width) debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtW.SelectAll();
                txtW.Focus();
                return;
            }

            // Validar que Height sea un número entero
            if (!int.TryParse(txtH.Text, out int h))
            {
                MessageBox.Show("La altura (Height) debe ser un número entero válido.\nNo se permiten letras ni caracteres especiales.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtH.SelectAll();
                txtH.Focus();
                return;
            }

            // Validar que Width y Height sean positivos
            if (w <= 0)
            {
                MessageBox.Show("El ancho (Width) debe ser un número positivo mayor que cero.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtW.SelectAll();
                txtW.Focus();
                return;
            }

            if (h <= 0)
            {
                MessageBox.Show("La altura (Height) debe ser un número positivo mayor que cero.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtH.SelectAll();
                txtH.Focus();
                return;
            }

            try
            {
                ventanaLogica = new Rectangle(x, y, w, h);
                picCanvas.Refresh();
                MessageBox.Show("Ventana de recorte configurada correctamente.", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar la ventana:\n{ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}