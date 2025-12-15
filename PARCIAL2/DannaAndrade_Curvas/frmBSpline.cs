using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DannaAndrade_Curvas
{
    public partial class frmBSpline : Form
    {
        private List<PointF> controlPoints = new List<PointF>();
        private int selectedIndex = -1;

        public frmBSpline()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            cmbGrado.SelectedIndex = 0; // Grado 3 por defecto
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                if (Math.Abs(controlPoints[i].X - e.X) < 8 && Math.Abs(controlPoints[i].Y - e.Y) < 8)
                {
                    selectedIndex = i; return;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                controlPoints.Add(e.Location);
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

            // CORRECCIÓN AQUÍ:
            // 1. Solo dibujamos las líneas grises si hay 2 o más puntos
            if (controlPoints.Count > 1)
            {
                e.Graphics.DrawLines(Pens.LightGray, controlPoints.ToArray());
            }

            // 2. Los puntos (cuadritos verdes) se dibujan siempre, aunque solo haya uno
            foreach (var p in controlPoints)
            {
                e.Graphics.FillRectangle(Brushes.Green, p.X - 3, p.Y - 3, 6, 6);
            }

            // --- LÓGICA DE LA CURVA B-SPLINE ---

            // Validar condición B-Spline: n >= p + 1
            // Grado p = indice del combo + 2 (0->2, 1->3, etc)
            int degree = cmbGrado.SelectedIndex + 2;

            if (controlPoints.Count > degree)
            {
                try
                {
                    List<PointF> curve = new List<PointF>();
                    bool clamped = rdoClamped.Checked;

                    // Generar vector de nodos
                    List<double> knots = CurveMath.GenerateKnotVector(controlPoints.Count - 1, degree, clamped);

                    // Definir rango de u
                    double uStart = knots[degree];
                    double uEnd = knots[controlPoints.Count];

                    // Ajuste para Clamped
                    if (clamped)
                    {
                        uStart = 0;
                        uEnd = 1;
                    }

                    double step = (uEnd - uStart) / 100.0;

                    for (double u = uStart; u <= uEnd - step / 2; u += step)
                    {
                        curve.Add(CurveMath.CalculateBSplinePoint(controlPoints, degree, u, knots));
                    }

                    // Asegurar dibujo de la curva solo si hay suficientes puntos calculados
                    if (curve.Count > 1)
                        e.Graphics.DrawLines(new Pen(Color.Magenta, 2), curve.ToArray());
                }
                catch
                {
                    /* Ignorar errores de cálculo en tiempo real */
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            picCanvas.Invalidate();
        }

        private void ForceRedraw(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }
    }
}