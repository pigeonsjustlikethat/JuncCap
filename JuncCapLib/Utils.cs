using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class Utils
    {
        public static double Gaussian(double x, double mean, double stdev)
        {
            return Math.Exp(-Math.Pow(x - mean, 2) / (2 * Math.Pow(stdev, 2))) / (Consts.Sqrt2Pi * stdev);
        }

        public static double Interpolate(double x, double xlo, double xhi, double ylo, double yhi)
        {
            return ylo + (x - xlo) * (yhi - ylo) / (xhi - xlo);
        }

        public static double BilinearInterpolate(
            double x, double xlo, double xhi, double y, double ylo, double yhi,
            double fll, double flh, double fhl, double fhh)
        {
            double flo = Interpolate(x, xlo, xhi, fll, fhl);
            double fhi = Interpolate(x, xlo, xhi, flh, fhh);
            return Interpolate(y, ylo, yhi, flo, fhi);
        }
    }
}
