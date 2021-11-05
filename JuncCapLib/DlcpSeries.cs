using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class DlcpSeries
    {
        public double Temperature { get; }
        public double Frequency { get; }
        public List<double> Positions { get; }
        public List<double> Densities { get; }
        public List<DlcpPoint> Points { get; }

        public DlcpSeries(double temperature, double frequency)
        {
            Points = new List<DlcpPoint>();
            Positions = new List<double>();
            Densities = new List<double>();
            Temperature = temperature;
            Frequency = frequency;
        }

        public void Add(DlcpPoint dlcpPoint)
        {
            Points.Add(dlcpPoint);
            Positions.Add(dlcpPoint.Position);
            Densities.Add(dlcpPoint.Density);
        }
    }
}
