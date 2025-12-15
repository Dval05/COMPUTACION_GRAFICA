using System;
using System.Collections.Generic;
using System.Drawing;

namespace DannaAndrade_Curvas
{
    public static class CurveMath
    {
        // ==========================================
        // MÓDULO BÉZIER (Algoritmo de Bernstein)
        // ==========================================

        private static long Factorial(int n)
        {
            if (n <= 1) return 1;
            long r = 1;
            for (int i = 2; i <= n; i++) r *= i;
            return r;
        }

        private static double Binomial(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            return Factorial(n) / (double)(Factorial(k) * Factorial(n - k));
        }

        public static PointF CalculateBezierPoint(List<PointF> points, double t)
        {
            int n = points.Count - 1;
            double x = 0, y = 0;

            for (int i = 0; i <= n; i++)
            {
                // Polinomio de Bernstein
                double b = Binomial(n, i) * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
                x += points[i].X * b;
                y += points[i].Y * b;
            }
            return new PointF((float)x, (float)y);
        }

        // ==========================================
        // MÓDULO B-SPLINE (Algoritmo Cox-de Boor)
        // ==========================================

        public static List<double> GenerateKnotVector(int n, int p, bool clamped)
        {
            // n = número de puntos - 1
            // p = grado
            // m = número de nodos - 1 = n + p + 1
            int m = n + p + 1;
            List<double> knots = new List<double>();

            if (clamped) // No uniforme (abierto/clamped)
            {
                for (int i = 0; i <= p; i++) knots.Add(0);
                for (int i = 1; i < n - p + 1; i++) knots.Add((double)i / (n - p + 1));
                for (int i = 0; i <= p; i++) knots.Add(1);
            }
            else // Uniforme
            {
                for (int i = 0; i <= m; i++) knots.Add(i);
            }
            return knots;
        }

        private static double BasisFunction(int i, int p, double u, List<double> knots)
        {
            if (p == 0)
            {
                return (u >= knots[i] && u < knots[i + 1]) ? 1 : 0;
            }

            double term1 = 0, term2 = 0;

            // Prevención de división por cero
            double denom1 = knots[i + p] - knots[i];
            if (denom1 != 0)
                term1 = ((u - knots[i]) / denom1) * BasisFunction(i, p - 1, u, knots);

            double denom2 = knots[i + p + 1] - knots[i + 1];
            if (denom2 != 0)
                term2 = ((knots[i + p + 1] - u) / denom2) * BasisFunction(i + 1, p - 1, u, knots);

            return term1 + term2;
        }

        public static PointF CalculateBSplinePoint(List<PointF> points, int degree, double u, List<double> knots)
        {
            double x = 0, y = 0;
            int n = points.Count - 1;

            // Sumatoria de P_i * N_{i,p}(u)
            for (int i = 0; i <= n; i++)
            {
                double val = BasisFunction(i, degree, u, knots);
                x += points[i].X * val;
                y += points[i].Y * val;
            }
            return new PointF((float)x, (float)y);
        }
    }
}