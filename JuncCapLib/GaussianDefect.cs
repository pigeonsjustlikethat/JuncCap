using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class GaussianDefect : Defect
    {
        public double Amplitude { get; }
        public double Mean { get; }
        public double StandardDeviation { get; }

        public GaussianDefect(double amplitude, double mean, double stdev)
        {
            Amplitude = amplitude;
            Mean = mean;
            StandardDeviation = stdev;
        }

        public override double GetDensity(double energy, double position)
        {
            return Amplitude * Utils.Gaussian(energy, Mean, StandardDeviation);
        }
    }
}
