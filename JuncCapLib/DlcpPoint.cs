using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace JuncCapLib
{
    public class DlcpPoint
    {
        public double Position { get; }
        public double Density { get; }

        public double Bias { get; }
        public double[] dVs { get; }
        public double[] Cs { get; }

        public DlcpPoint(double bias, double[] dVseries, double[] Cseries, double eps)
        {
            Bias = bias;
            dVs = dVseries;
            Cs = Cseries;
            
            var lineFitRes = Fit.Line(dVs, Cs);
            double c0guess = lineFitRes.Item1;
            double c1guess = lineFitRes.Item2;

            var quadFitRes = Fit.Polynomial(dVs, Cs, 2);
            double C0 = quadFitRes[0];
            double C1 = quadFitRes[1];
            double C2 = quadFitRes[2];
            Density = -(C0 * C0 * C0) / (2 * eps * Consts.ElementaryCharge * C1);
            Position = 2 * eps / C0;

            //var f = new Func<double, double, double, double>((x, a, b) => a * (Math.Sqrt(1 + b * x) - 1) / x);
            //double aGuess = -c0guess * c0guess / c1guess;
            //double bGuess = c0guess / aGuess;
            //Tuple<double, double> res = Fit.Curve(dVs, Cs, f, aGuess, bGuess);
            //double alpha = res.Item1;
            //double beta = res.Item2;
            //Density = alpha * alpha * beta / (2 * eps * area * area * Consts.ElementaryCharge);
            //Position = 2 * eps * area / (alpha * beta);

            //var f = new Func<double, double, double, double>((x, c0, c1) => c0 + c1 * x + 2 * (c1 * c1 / c0) * x * x);
            //Tuple<double, double> res = Fit.Curve(dVs, Cs, f, c0guess, c1guess);
            //double C0 = res.Item1;
            //double C1 = res.Item2;
            //Density = -C0 * C0 * C0 / (2 * eps * area * area * Consts.ElementaryCharge * C1);
            //Position = 2 * eps * area / C1;

        }
    }
}
