using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public class CAlgoritmosLineas
    {
        private const int PIXEL_SIZE = 10; // Tamaño del cuadro
        private const int DELAY = 10;      // Velocidad de animación (ms)
        private Bitmap mBitmap;

        // Método auxiliar para preparar el lienzo con cuadrícula
        public void InicializarCanvas(PictureBox pic)
        {
            mBitmap = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);
                // Dibujar Grid
                Pen p = new Pen(Color.LightGray);
                for (int i = 0; i < pic.Width; i += PIXEL_SIZE) g.DrawLine(p, i, 0, i, pic.Height);
                for (int j = 0; j < pic.Height; j += PIXEL_SIZE) g.DrawLine(p, 0, j, pic.Width, j);

                // Ejes centrales
                Pen axis = new Pen(Color.Black, 2);
                g.DrawLine(axis, pic.Width / 2, 0, pic.Width / 2, pic.Height);
                g.DrawLine(axis, 0, pic.Height / 2, pic.Width, pic.Height / 2);
            }
            pic.Image = mBitmap;
        }

        // Método auxiliar para pintar un "píxel" en la cuadrícula
        private void PintarPixel(Graphics g, int xLogico, int yLogico, int w, int h, Color color)
        {
            int cx = (w / PIXEL_SIZE) / 2;
            int cy = (h / PIXEL_SIZE) / 2;

            int screenX = (cx + xLogico) * PIXEL_SIZE;
            int screenY = (cy - yLogico) * PIXEL_SIZE; // Y invertida en pantalla

            using (SolidBrush b = new SolidBrush(color))
            {
                g.FillRectangle(b, screenX, screenY, PIXEL_SIZE, PIXEL_SIZE);
                g.DrawRectangle(Pens.Black, screenX, screenY, PIXEL_SIZE, PIXEL_SIZE);
            }
        }

        // --- 1. DDA ANIMADO ---
        public async Task DibujarDDA(PictureBox pic, int x0, int y0, int x1, int y1)
        {
            if (pic.Image == null) InicializarCanvas(pic);
            mBitmap = (Bitmap)pic.Image;

            float dx = x1 - x0;
            float dy = y1 - y0;
            int steps = (int)Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xInc = dx / steps;
            float yInc = dy / steps;
            float x = x0;
            float y = y0;

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                for (int i = 0; i <= steps; i++)
                {
                    PintarPixel(g, (int)Math.Round(x), (int)Math.Round(y), pic.Width, pic.Height, Color.Blue);
                    x += xInc;
                    y += yInc;

                    pic.Refresh(); // Forzar dibujado
                    await Task.Delay(DELAY); // Pausa para animación
                }
            }
        }

        // --- 2. BRESENHAM ANIMADO ---
        public async Task DibujarBresenham(PictureBox pic, int x0, int y0, int x1, int y1)
        {
            if (pic.Image == null) InicializarCanvas(pic);
            mBitmap = (Bitmap)pic.Image;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                while (true)
                {
                    PintarPixel(g, x0, y0, pic.Width, pic.Height, Color.Red);
                    pic.Refresh();
                    await Task.Delay(DELAY);

                    if (x0 == x1 && y0 == y1) break;
                    int e2 = 2 * err;
                    if (e2 > -dy) { err -= dy; x0 += sx; }
                    if (e2 < dx) { err += dx; y0 += sy; }
                }
            }
        }

        // --- 3. PUNTO MEDIO ANIMADO ---
        public async Task DibujarPuntoMedio(PictureBox pic, int x0, int y0, int x1, int y1)
        {
            if (pic.Image == null) InicializarCanvas(pic);
            mBitmap = (Bitmap)pic.Image;

            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 2 * dy - dx; // Simplificado para Octante 1, generalizar si es necesario
            int incrE = 2 * dy;
            int incrNE = 2 * (dy - dx);
            int x = x0, y = y0;

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                PintarPixel(g, x, y, pic.Width, pic.Height, Color.Green);
                pic.Refresh();
                await Task.Delay(DELAY);

                while (x < x1)
                {
                    if (d <= 0) { d += incrE; x++; }
                    else { d += incrNE; x++; y++; }

                    PintarPixel(g, x, y, pic.Width, pic.Height, Color.Green);
                    pic.Refresh();
                    await Task.Delay(DELAY);
                }
            }
        }
    }
}