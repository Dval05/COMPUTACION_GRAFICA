using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public class CAlgoritmosCircunferencia
    {
        private const int PIXEL_SIZE = 10;
        private const int DELAY = 15;
        private Bitmap mBitmap;

        // Pinta visual y lógicamente para que el relleno detecte el borde
        private void PintarPixel(Graphics g, int xLogico, int yLogico, int w, int h, Color c)
        {
            int cx = (w / PIXEL_SIZE) / 2;
            int cy = (h / PIXEL_SIZE) / 2;
            int screenX = (cx + xLogico) * PIXEL_SIZE;
            int screenY = (cy - yLogico) * PIXEL_SIZE;

            if (screenX >= 0 && screenX < w && screenY >= 0 && screenY < h)
            {
                // Visual
                using (SolidBrush b = new SolidBrush(c))
                {
                    g.FillRectangle(b, screenX, screenY, PIXEL_SIZE, PIXEL_SIZE);
                    g.DrawRectangle(Pens.Black, screenX, screenY, PIXEL_SIZE, PIXEL_SIZE);
                }
                // Lógico: Actualizar el centro del pixel en el bitmap
                mBitmap.SetPixel(screenX + PIXEL_SIZE / 2, screenY + PIXEL_SIZE / 2, c);
            }
        }

        public async Task DibujarBresenham(PictureBox pic, int radio, Color c)
        {
            mBitmap = (Bitmap)pic.Image;
            int x = 0;
            int y = radio;
            int d = 3 - 2 * radio;        

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                while (y >= x)
                {
                    Pintar8Simetria(g, 0, 0, x, y, pic.Width, pic.Height, c);
                    pic.Refresh();
                    await Task.Delay(DELAY);
                    x++;
                    if (d > 0) { y--; d = d + 4 * (x - y) + 10; }
                    else { d = d + 4 * x + 6; }
                }
            }


        }

        // Implementar Parametrico y Algebraico de la misma forma usando Pintar8Simetria...

        private void Pintar8Simetria(Graphics g, int xc, int yc, int x, int y, int w, int h, Color c)
        {
            PintarPixel(g, xc + x, yc + y, w, h, c);
            PintarPixel(g, xc - x, yc + y, w, h, c);
            PintarPixel(g, xc + x, yc - y, w, h, c);
            PintarPixel(g, xc - x, yc - y, w, h, c);
            PintarPixel(g, xc + y, yc + x, w, h, c);
            PintarPixel(g, xc - y, yc + x, w, h, c);
            PintarPixel(g, xc + y, yc - x, w, h, c);
            PintarPixel(g, xc - y, yc - x, w, h, c);
        }

        public async Task DibujarParametrico(PictureBox pic, int radio, Color c)
        {
            mBitmap = (Bitmap)pic.Image;
            // Paso muy fino para asegurar que no haya huecos en el borde
            double step = 1.0 / (radio * 3.0);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                for (double theta = 0; theta <= Math.PI / 4; theta += step)
                {
                    int x = (int)Math.Round(radio * Math.Cos(theta));
                    int y = (int)Math.Round(radio * Math.Sin(theta));
                    Pintar8Simetria(g, 0, 0, x, y, pic.Width, pic.Height, c);
                    pic.Refresh();
                    await Task.Delay(DELAY);
                }
            }
        }

        public async Task DibujarAlgebraico(PictureBox pic, int radio, Color c)
        {
            mBitmap = (Bitmap)pic.Image;
            int limit = (int)Math.Round(radio / Math.Sqrt(2));
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                for (int x = 0; x <= limit; x++)
                {
                    int y = (int)Math.Round(Math.Sqrt(radio * radio - x * x));
                    Pintar8Simetria(g, 0, 0, x, y, pic.Width, pic.Height, c);
                    pic.Refresh();
                    await Task.Delay(DELAY);
                }
            }
        }
    }
}