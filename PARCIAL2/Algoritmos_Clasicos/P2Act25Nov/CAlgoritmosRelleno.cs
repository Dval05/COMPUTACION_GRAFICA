using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public class CAlgoritmosRelleno
    {
        private const int PIXEL_SIZE = 10; // Debe ser IDÉNTICO al usado en Circunferencia/Líneas
        private const int DELAY = 2;       // Retardo bajo para que no sea eterno

        // --- HELPERS ---

        // Pinta visualmente Y actualiza el dato lógico
        private void PintarCelda(Bitmap bmp, Graphics g, int gridX, int gridY, Color c)
        {
            int sx = gridX * PIXEL_SIZE;
            int sy = gridY * PIXEL_SIZE;

            // 1. Pintar Visualmente 
            using (SolidBrush b = new SolidBrush(c))
            {
                g.FillRectangle(b, sx, sy, PIXEL_SIZE, PIXEL_SIZE);
            }
            using (Pen p = new Pen(Color.FromArgb(50, 0, 0, 0))) // Borde tenue para ver la grilla
            {
                g.DrawRectangle(p, sx, sy, PIXEL_SIZE - 1, PIXEL_SIZE - 1);
            }

            // 2. Actualizar Lógica (Lento pero seguro para GetPixel)
            // Pinta un pixel "centinela" en el centro del cuadro del bitmap para que GetPixel lo lea correctamente después
            int cx = sx + PIXEL_SIZE / 2;
            int cy = sy + PIXEL_SIZE / 2;
            if (cx < bmp.Width && cy < bmp.Height)
            {
                bmp.SetPixel(cx, cy, c);
            }
        }

        // Lee el color del CENTRO de la celda
        private Color GetColorCelda(Bitmap bmp, int gridX, int gridY)
        {
            int cx = gridX * PIXEL_SIZE + PIXEL_SIZE / 2;
            int cy = gridY * PIXEL_SIZE + PIXEL_SIZE / 2;

            if (cx < 0 || cx >= bmp.Width || cy < 0 || cy >= bmp.Height)
                return Color.Black; // Retornar un color "muro" si sale del rango

            return bmp.GetPixel(cx, cy);
        }

        private bool ColoresIguales(Color a, Color b)
        {
            return a.ToArgb() == b.ToArgb();
        }

        // --- ALGORITMOS ---

        // 1. FLOOD FILL
        public async Task FloodFillIterativo(Bitmap bmp, PictureBox pic, int mouseX, int mouseY, Color target, Color fill)
        {

            if (ColoresIguales(target, fill)) return;

            int gridX = mouseX / PIXEL_SIZE;
            int gridY = mouseY / PIXEL_SIZE;
            int gridW = pic.Width / PIXEL_SIZE;
            int gridH = pic.Height / PIXEL_SIZE;

            if (!ColoresIguales(GetColorCelda(bmp, gridX, gridY), target)) return;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(gridX, gridY));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int refresh = 0;
                while (stack.Count > 0)
                {
                    Point p = stack.Pop();

                    if (p.X < 0 || p.X >= gridW || p.Y < 0 || p.Y >= gridH) continue;

                    // Si el pixel actual es del color objetivo (Fondo), lo pintamos
                    if (ColoresIguales(GetColorCelda(bmp, p.X, p.Y), target))
                    {
                        PintarCelda(bmp, g, p.X, p.Y, fill);

                        stack.Push(new Point(p.X + 1, p.Y));
                        stack.Push(new Point(p.X - 1, p.Y));
                        stack.Push(new Point(p.X, p.Y + 1));
                        stack.Push(new Point(p.X, p.Y - 1));

                        refresh++;
                        if (refresh % 5 == 0) { pic.Refresh(); await Task.Delay(DELAY); }
                    }
                }
            }
            pic.Refresh();
        }

        // 2. BOUNDARY FILL (El que suele desbordarse si el color no coincide)
        public async Task BoundaryFill(Bitmap bmp, PictureBox pic, int mouseX, int mouseY, Color boundaryColor, Color fillColor)
        {
            int gridX = mouseX / PIXEL_SIZE;
            int gridY = mouseY / PIXEL_SIZE;
            int gridW = pic.Width / PIXEL_SIZE;
            int gridH = pic.Height / PIXEL_SIZE;

            // Si empezamos sobre el borde o sobre lo ya pintado, salir
            Color startColor = GetColorCelda(bmp, gridX, gridY);
            if (ColoresIguales(startColor, boundaryColor) || ColoresIguales(startColor, fillColor)) return;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(gridX, gridY));

            // Usamos una matriz de visitados para evitar bucles infinitos en áreas grandes
            bool[,] visited = new bool[gridW + 1, gridH + 1];

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int refresh = 0;
                while (stack.Count > 0)
                {
                    Point p = stack.Pop();

                    if (p.X < 0 || p.X >= gridW || p.Y < 0 || p.Y >= gridH) continue;
                    if (visited[p.X, p.Y]) continue;

                    Color actual = GetColorCelda(bmp, p.X, p.Y);

                    // CONDICIÓN CRÍTICA:
                    // Sigue pintando SIEMPRE QUE: No sea Borde Y No sea el color de Relleno
                    if (!ColoresIguales(actual, boundaryColor) && !ColoresIguales(actual, fillColor))
                    {
                        visited[p.X, p.Y] = true;
                        PintarCelda(bmp, g, p.X, p.Y, fillColor);

                        stack.Push(new Point(p.X + 1, p.Y));
                        stack.Push(new Point(p.X - 1, p.Y));
                        stack.Push(new Point(p.X, p.Y + 1));
                        stack.Push(new Point(p.X, p.Y - 1));

                        refresh++;
                        if (refresh % 5 == 0) { pic.Refresh(); await Task.Delay(DELAY); }
                    }
                }
            }
            pic.Refresh();
        }

        // 3. SCANLINE FILL
        public async Task ScanLineFill(Bitmap bmp, PictureBox pic, int mouseX, int mouseY, Color target, Color fill)
        {
            if (ColoresIguales(target, fill)) return;

            int gridX = mouseX / PIXEL_SIZE;
            int gridY = mouseY / PIXEL_SIZE;
            int gridW = pic.Width / PIXEL_SIZE;
            int gridH = pic.Height / PIXEL_SIZE;

            if (!ColoresIguales(GetColorCelda(bmp, gridX, gridY), target)) return;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(gridX, gridY));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                while (stack.Count > 0)
                {
                    Point p = stack.Pop();
                    int x = p.X;
                    int y = p.Y;

                    if (y < 0 || y >= gridH) continue;
                    if (!ColoresIguales(GetColorCelda(bmp, x, y), target)) continue;

                    // Encontrar extremos de la línea horizontal
                    int lx = x;
                    while (lx > 0 && ColoresIguales(GetColorCelda(bmp, lx - 1, y), target)) lx--;

                    int rx = x;
                    while (rx < gridW - 1 && ColoresIguales(GetColorCelda(bmp, rx + 1, y), target)) rx++;

                    // Pintar la línea
                    for (int i = lx; i <= rx; i++)
                    {
                        PintarCelda(bmp, g, i, y, fill);
                    }
                    pic.Refresh();
                    await Task.Delay(DELAY * 2);

                    // Escanear líneas arriba y abajo
                    CheckScanLine(bmp, lx, rx, y - 1, target, stack);
                    CheckScanLine(bmp, lx, rx, y + 1, target, stack);
                }
            }
            pic.Refresh();
        }

        private void CheckScanLine(Bitmap bmp, int lx, int rx, int y, Color target, Stack<Point> stack)
        {
            bool spanAdded = false;
            // Validar límites Y
            if (y < 0 || y >= (bmp.Height / PIXEL_SIZE)) return;

            for (int i = lx; i <= rx; i++)
            {
                if (ColoresIguales(GetColorCelda(bmp, i, y), target))
                {
                    if (!spanAdded)
                    {
                        stack.Push(new Point(i, y));
                        spanAdded = true;
                    }
                }
                else
                {
                    spanAdded = false;
                }
            }
        }
    }
}