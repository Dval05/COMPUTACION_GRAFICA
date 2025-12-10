using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public class CRecorteLineas
    {
        private const int PIXEL_SIZE = 15;
        private const int DELAY = 15;

        private int xMin, xMax, yMin, yMax;

        private const int INSIDE = 0;
        private const int LEFT = 1;
        private const int RIGHT = 2;
        private const int BOTTOM = 4;
        private const int TOP = 8;

        public void SetVentana(int x1, int x2, int y1, int y2)
        {
            xMin = Math.Min(x1, x2);
            xMax = Math.Max(x1, x2);
            yMin = Math.Min(y1, y2);
            yMax = Math.Max(y1, y2);
        }

        // COORDENADAS UNIFICADAS
        private Point ToScreen(int x, int y, int w, int h)
        {
            int cx = (w / PIXEL_SIZE) / 2;
            int cy = (h / PIXEL_SIZE) / 2;
            return new Point(
                (cx + x) * PIXEL_SIZE + (PIXEL_SIZE / 2),
                (cy - y) * PIXEL_SIZE + (PIXEL_SIZE / 2)
            );
        }

        private async Task AnimarLineaLapiz(Graphics g, PictureBox pic, Point p1, Point p2, Color c)
        {
            Point s1 = ToScreen(p1.X, p1.Y, pic.Width, pic.Height);
            Point s2 = ToScreen(p2.X, p2.Y, pic.Width, pic.Height);

            float xStart = s1.X; float yStart = s1.Y;
            float xEnd = s2.X; float yEnd = s2.Y;

            float steps = 20;
            float dx = (xEnd - xStart) / steps;
            float dy = (yEnd - yStart) / steps;

            using (Pen lapiz = new Pen(c, 3))
            {
                lapiz.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                lapiz.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                float xActual = xStart;
                float yActual = yStart;

                for (int i = 0; i < steps; i++)
                {
                    float xSiguiente = xActual + dx;
                    float ySiguiente = yActual + dy;
                    g.DrawLine(lapiz, xActual, yActual, xSiguiente, ySiguiente);
                    xActual = xSiguiente;
                    yActual = ySiguiente;
                    pic.Refresh();
                    await Task.Delay(DELAY);
                }
                g.DrawLine(lapiz, xActual, yActual, xEnd, yEnd);
                pic.Refresh();
            }
        }

        // ALGORITMOS (Sin cambios lógicos, solo llamadas a Animar)
        public async Task EjecutarCohenSutherland(Graphics g, PictureBox pic, Point p1, Point p2)
        {
            double x0 = p1.X, y0 = p1.Y, x1 = p2.X, y1 = p2.Y;
            int outcode0 = ComputeOutCode(x0, y0);
            int outcode1 = ComputeOutCode(x1, y1);
            bool accept = false;

            while (true)
            {
                if ((outcode0 | outcode1) == 0) { accept = true; break; }
                else if ((outcode0 & outcode1) != 0) { break; }
                else
                {
                    double x = 0, y = 0;
                    int outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;

                    if ((outcodeOut & TOP) != 0) { x = x0 + (x1 - x0) * (yMax - y0) / (y1 - y0); y = yMax; }
                    else if ((outcodeOut & BOTTOM) != 0) { x = x0 + (x1 - x0) * (yMin - y0) / (y1 - y0); y = yMin; }
                    else if ((outcodeOut & RIGHT) != 0) { y = y0 + (y1 - y0) * (xMax - x0) / (x1 - x0); x = xMax; }
                    else if ((outcodeOut & LEFT) != 0) { y = y0 + (y1 - y0) * (xMin - x0) / (x1 - x0); x = xMin; }

                    if (outcodeOut == outcode0) { x0 = x; y0 = y; outcode0 = ComputeOutCode(x0, y0); }
                    else { x1 = x; y1 = y; outcode1 = ComputeOutCode(x1, y1); }
                }
            }

            if (accept)
                await AnimarLineaLapiz(g, pic, new Point((int)x0, (int)y0), new Point((int)x1, (int)y1), Color.Blue);
        }

        public async Task EjecutarLiangBarsky(Graphics g, PictureBox pic, Point p1, Point p2)
        {
            double t0 = 0.0, t1 = 1.0;
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;

            if (ClipTest(-dx, p1.X - xMin, ref t0, ref t1))
            {
                if (ClipTest(dx, xMax - p1.X, ref t0, ref t1))
                {
                    if (ClipTest(-dy, p1.Y - yMin, ref t0, ref t1))
                    {
                        if (ClipTest(dy, yMax - p1.Y, ref t0, ref t1))
                        {
                            Point pInicio = new Point((int)(p1.X + t0 * dx), (int)(p1.Y + t0 * dy));
                            Point pFin = new Point((int)(p1.X + t1 * dx), (int)(p1.Y + t1 * dy));
                            await AnimarLineaLapiz(g, pic, pInicio, pFin, Color.Red);
                        }
                    }
                }
            }
        }

        public async Task EjecutarPuntoMedio(Graphics g, PictureBox pic, Point p1, Point p2)
        {
            await EjecutarCohenSutherland(g, pic, p1, p2);
        }

        private int ComputeOutCode(double x, double y)
        {
            int code = INSIDE;
            if (x < xMin) code |= LEFT;
            else if (x > xMax) code |= RIGHT;
            if (y < yMin) code |= BOTTOM;
            else if (y > yMax) code |= TOP;
            return code;
        }

        private bool ClipTest(double p, double q, ref double t0, ref double t1)
        {
            double r = q / p;
            if (p < 0) { if (r > t1) return false; if (r > t0) t0 = r; }
            else if (p > 0) { if (r < t0) return false; if (r < t1) t1 = r; }
            else if (q < 0) return false;
            return true;
        }
    }
}