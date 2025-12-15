using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DannaAndrade_Curvas
{
    public partial class frmBezier : Form
    {
        private List<PointF> controlPoints = new List<PointF>();
        private int selectedIndex = -1;

        public frmBezier()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            cmbTipo.SelectedIndex = 0; // Por defecto Lineal
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // 1. Intentar seleccionar punto existente
            for (int i = 0; i < controlPoints.Count; i++)
            {
                if (Math.Abs(controlPoints[i].X - e.X) < 8 && Math.Abs(controlPoints[i].Y - e.Y) < 8)
                {
                    selectedIndex = i;
                    return;
                }
            }

            // 2. Si no selecciona, agregar punto (Click Izquierdo)
            if (e.Button == MouseButtons.Left)
            {
                // Validar límites según tipo seleccionado
                if (cmbTipo.SelectedIndex == 0 && controlPoints.Count >= 2) { MessageBox.Show("Bézier Lineal solo permite 2 puntos."); return; }
                if (cmbTipo.SelectedIndex == 1 && controlPoints.Count >= 3) { MessageBox.Show("Bézier Cuadrática solo permite 3 puntos."); return; }
                if (cmbTipo.SelectedIndex == 2 && controlPoints.Count >= 4) { MessageBox.Show("Bézier Cúbica solo permite 4 puntos."); return; }

                controlPoints.Add(e.Location);
                picCanvas.Invalidate();
            }
            // 3. Eliminar punto (Click Derecho)
            else if (e.Button == MouseButtons.Right && controlPoints.Count > 0)
            {
                controlPoints.RemoveAt(controlPoints.Count - 1);
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedIndex != -1 && e.Button == MouseButtons.Left)
            {
                controlPoints[selectedIndex] = e.Location;
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            selectedIndex = -1;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar Polilínea
            if (controlPoints.Count > 1 && chkPolilinea.Checked)
                e.Graphics.DrawLines(Pens.LightGray, controlPoints.ToArray());

            // Dibujar Puntos
            for (int i = 0; i < controlPoints.Count; i++)
            {
                e.Graphics.FillEllipse(Brushes.Red, controlPoints[i].X - 4, controlPoints[i].Y - 4, 8, 8);
                e.Graphics.DrawString("P" + i, this.Font, Brushes.Black, controlPoints[i].X + 5, controlPoints[i].Y - 5);
            }

            // Dibujar Curva
            if (controlPoints.Count >= 2)
            {
                List<PointF> curve = new List<PointF>();
                for (double t = 0; t <= 1; t += 0.005)
                {
                    curve.Add(CurveMath.CalculateBezierPoint(controlPoints, t));
                }
                curve.Add(controlPoints[controlPoints.Count - 1]); // Cerrar exacto
                e.Graphics.DrawLines(new Pen(Color.Blue, 2), curve.ToArray());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            picCanvas.Invalidate();
        }

        // Manejador genérico para forzar repintado desde controles de UI
        private void ForceRedraw(object sender, EventArgs e)
        {
            controlPoints.Clear(); // Limpiar al cambiar de modo para evitar conflictos
            picCanvas.Invalidate();
        }

        // Manejador solo para el checkbox (no limpia puntos)
        private void UpdateView(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }
    }
}