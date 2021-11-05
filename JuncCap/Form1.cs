using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using JuncCapLib;

namespace JuncCap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Run();
        }

        private void Run()
        {
            Device device = GetDevice();

            //NoumerovSolver noumerovSolver = new NoumerovSolver(device);

            double freq = (double)numericUpDownFreq.Value;//500;
            double T = (double)numericUpDownT.Value;//300;
            double dV = (double)numericUpDownDV.Value * 1e-3;
            double bias = (double)numericUpDownBias.Value;
            //noumerovSolver.SolveDC();
            device.SolveDC(bias);
            device.SolveAC(bias, dV, freq, T);
            double C = device.MeasureCapacitance(bias, dV, freq, T) * 1e5;
            textBoxCap.Text = $"C = {Math.Round(C, 6)} nF/cm²";

            Series seriesRho = new Series()
            {
                Name = "rho",
                ChartType = SeriesChartType.Line
            };

            Series seriesRhoAC = new Series()
            {
                Name = "rhoAC",
                ChartType = SeriesChartType.Line
            };

            Series seriesPhi = new Series()
            {
                Name = "phi",
                ChartType = SeriesChartType.Line
            };

            Series seriesFermi = new Series()
            {
                Name = "EF",
                ChartType = SeriesChartType.Line
            };

            Series seriesEe = new Series()
            {
                Name = "Ee",
                ChartType = SeriesChartType.Line
            };

            Series seriesPhiAC = new Series()
            {
                Name = "phiAC",
                ChartType = SeriesChartType.Line
            };

            chart1.Series.Clear();
            chart1.Series.Add(seriesRho);
            chart1.Series.Add(seriesRhoAC);
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = device.Thickness * 1e6;//thickness_um;

            chart2.Series.Clear();
            chart2.Series.Add(seriesPhi);
            chart2.Series.Add(seriesFermi);
            chart2.Series.Add(seriesEe);
            chart2.Series.Add(seriesPhiAC);
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = device.Thickness * 1e6;//thickness_um;

            double Ee = device.CalcEe(freq, T);

            for (int i = 0; i < device.NumPointsPosition; i++)
            {
                seriesRho.Points.AddXY(device.PositionSpacing * i * 1e6, device.RhoDC[i]);
                seriesRhoAC.Points.AddXY(device.PositionSpacing * i * 1e6, device.RhoAC[i]);
                seriesPhi.Points.AddXY(device.PositionSpacing * i * 1e6, device.PhiDC[i] / Consts.ElementaryCharge);
                seriesFermi.Points.AddXY(device.PositionSpacing * i * 1e6, device.FermiDC[i] / Consts.ElementaryCharge);
                seriesEe.Points.AddXY(device.PositionSpacing * i * 1e6, (device.FermiDC[i] + Ee) / Consts.ElementaryCharge);
                seriesPhiAC.Points.AddXY(device.PositionSpacing * i * 1e6, device.PhiAC[i] / Consts.ElementaryCharge);
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            Run();
        }

        private void buttonRunDlcp_Click(object sender, EventArgs e)
        {
            Device device = GetDevice();

            var dlscpSeries = device.MeasureDlcpSeries(1000, 250, 0.5, -0.1, 6, 0.03, 0.01, 5);

            Series seriesNdl = new Series()
            {
                Name = "Ndl",
                ChartType = SeriesChartType.Point
            };

            chart3.Series.Clear();
            chart3.Series.Add(seriesNdl);
            foreach (var pt in dlscpSeries.Points)
            {
                seriesNdl.Points.AddXY(pt.Position * 1e6, Math.Log10(pt.Density * 1e-6));
            }

            chart4.Series.Clear();
            for (int j = 0; j < dlscpSeries.Points.Count; j++)
            {
                DlcpPoint pt = dlscpSeries.Points[j];
                chart4.Series.Add(new Series() { Name = $"{pt.Bias}", ChartType = SeriesChartType.Point });
                for (int i = 0; i < pt.dVs.Length; i++)
                {
                    chart4.Series[j].Points.AddXY(pt.dVs[i], pt.Cs[i]);
                }
            }
            chart4.ChartAreas[0].AxisY.Minimum = 2e-5;
        }

        private Device GetDevice()
        {
            double bandgap_J = (double)numericUpDownEg.Value * Consts.ElementaryCharge;
            double fermiLevel_J = -1 * (double)numericUpDownEf.Value * Consts.ElementaryCharge;
            double thickness_um = (double)numericUpDownThickness.Value;

            List<Defect> defects = new List<Defect>();
            defects.Add(new GaussianDefect(32.5, fermiLevel_J, 0.03 * Consts.ElementaryCharge / 2.3548));
            defects.Add(new GaussianDefect(3, 2 * fermiLevel_J, 0.1 * Consts.ElementaryCharge / 2.3548));

            Device device = new Device(
                bandgap_J,
                fermiLevel_J,
                thickness_um * 1e-6,
                (double)numericUpDownVbi.Value,
                (double)numericUpDown5.Value * Consts.VacuumPermittivity,
                5e4,
                defects,
                1000,
                500,
                1e-6);

            return device;
        }
    }
}
