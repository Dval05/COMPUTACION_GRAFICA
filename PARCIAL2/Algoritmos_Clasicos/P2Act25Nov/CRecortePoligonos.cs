using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2Act25Nov
{
    public class CRecortePoligonos
    {
        private const int PIXEL_SIZE = 15;
        private enum Borde { Izquierda, Derecha, Arriba, Abajo }

        // COORDENADAS UNIFICADAS
        private PointF ToScreen(int x, int y, int w, int h)
        {
            int cx = (w / PIXEL_SIZE) / 2;
            int cy = (h / PIXEL_SIZE) / 2;
            return new PointF(
                (cx + x) * PIXEL_SIZE + (PIXEL_SIZE / 2f),
                (cy - y) * PIXEL_SIZE + (PIXEL_SIZE / 2f)
            );
        }

        private async Task AnimarPoligonoLapiz(Graphics g, PictureBox pic, List<Point> puntos, Color c)
        {
            if (puntos.Count < 2) return;

            // Convertir Puntos Lógicos a Pantalla usando la fórmula estandarizada
            List<PointF> ptsPantalla = new List<PointF>();
            foreach (var p in puntos)
            {
                ptsPantalla.Add(ToScreen(p.X, p.Y, pic.Width, pic.Height));
            }

            using (Pen lapiz = new Pen(c, 3))
            {
                lapiz.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                // Dibujar líneas
                for (int i = 0; i < ptsPantalla.Count; i++)
                {
                    PointF p1 = ptsPantalla[i];
                    PointF p2 = ptsPantalla[(i + 1) % ptsPantalla.Count];
                    g.DrawLine(lapiz, p1, p2);
                    pic.Refresh();
                    await Task.Delay(100);
                }

                // Rellenar suave
                using (SolidBrush relleno = new SolidBrush(Color.FromArgb(50, c)))
                {
                    g.FillPolygon(relleno, ptsPantalla.ToArray());
                }
                pic.Refresh();
            }
        }

        public async Task EjecutarSutherlandHodgman(Graphics g, PictureBox pic, List<Point> poly, int xMin, int xMax, int yMin, int yMax)
        {
            List<Point> output = poly;
            output = ClipEdge(output, xMin, Borde.Izquierda);
            output = ClipEdge(output, xMax, Borde.Derecha);
            output = ClipEdge(output, yMax, Borde.Arriba);
            output = ClipEdge(output, yMin, Borde.Abajo);

            await AnimarPoligonoLapiz(g, pic, output, Color.Green);
        }

        public async Task EjecutarWeilerAtherton(Graphics g, PictureBox pic, List<Point> poly, int xMin, int xMax, int yMin, int yMax)
        {
            List<Point> output = ClipEdge(poly, xMin, Borde.Izquierda);
            output = ClipEdge(output, xMax, Borde.Derecha);
            output = ClipEdge(output, yMax, Borde.Arriba);
            output = ClipEdge(output, yMin, Borde.Abajo);

            await AnimarPoligonoLapiz(g, pic, output, Color.OrangeRed);
        }

        public async Task EjecutarRecorteRectangular(Graphics g, PictureBox pic, List<Point> poly, int xMin, int xMax, int yMin, int yMax)
        {
            List<Point> output = new List<Point>();
            foreach (var p in poly)
            {
                if (p.X >= xMin && p.X <= xMax && p.Y <= yMax && p.Y >= yMin)
                {
                    output.Add(p);
                }
            }
            // Para el modo rectangular simple, si quedan pocos puntos, intentamos dibujar lo que hay
            // Ojo: Este algoritmo es ingenuo y solo muestra vértices dentro, no recorta aristas.
            if (output.Count > 0)
                await AnimarPoligonoLapiz(g, pic, output, Color.Purple);
        }

        private List<Point> ClipEdge(List<Point> input, int edgeVal, Borde type)
        {
            List<Point> newPoly = new List<Point>();
            if (input.Count == 0) return newPoly;

            Point S = input[input.Count - 1];
            foreach (Point E in input)
            {
                if (IsInside(E, edgeVal, type))
                {
                    if (!IsInside(S, edgeVal, type)) newPoly.Add(Intersection(S, E, edgeVal, type));
                    newPoly.Add(E);
                }
                else if (IsInside(S, edgeVal, type))
                {
                    newPoly.Add(Intersection(S, E, edgeVal, type));
                }
                S = E;
            }
            return newPoly;
        }

        private bool IsInside(Point p, int val, Borde type)
        {
            switch (type)
            {
                case Borde.Izquierda: return p.X >= val;
                case Borde.Derecha: return p.X <= val;
                case Borde.Arriba: return p.Y <= val;
                case Borde.Abajo: return p.Y >= val;
                default: return false;
            }
        }

        private Point Intersection(Point S, Point E, int val, Borde type)
        {
            if (S.X == E.X && (type == Borde.Izquierda || type == Borde.Derecha)) return new Point(val, S.Y);
            if (S.Y == E.Y && (type == Borde.Arriba || type == Borde.Abajo)) return new Point(S.X, val);

            double m = (double)(E.Y - S.Y) / (E.X - S.X);
            if (type == Borde.Izquierda || type == Borde.Derecha)
                return new Point(val, (int)(S.Y + m * (val - S.X)));
            else
                return new Point((int)(S.X + (val - S.Y) / m), val);
        }
    }
}