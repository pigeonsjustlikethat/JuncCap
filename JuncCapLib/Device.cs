using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class Device
    {
        // Fundamental properties
        public int NumPointsPosition { get; }
        public int NumPointsEnergy { get; }
        public double Tolerance { get; }
        public double BandGap { get; }
        public double FermiLevel { get; }
        public double Thickness { get; }
        public double BuiltInVoltage { get; }
        public double DielectricConstant { get; }
        public double ThermalEmissionPrefactor { get; }
        public List<Defect> Defects { get; }

        // Derived properties
        public double EnergySpacing { get; }
        public double PositionSpacing { get; }
        public DensityOfStates DensityOfStates { get; }
        public RhoTable RhoTable { get; }

        public double TotalChargeDC { get; set; }
        public double TotalChargeAC { get; set; }

        public double[] FermiDC { get; }
        public double[] PhiDC { get; }
        public double[] RhoDC { get; }

        public double[] FermiAC { get; }
        public double[] PhiAC { get; }
        public double[] RhoAC { get; }

        public Device(
            double bandGap,
            double fermiLevel,
            double thickness,
            double builtInVoltage,
            double dielectricConstant,
            double thermalEmissionPrefactor,
            List<Defect> defects,
            int numPointsPosition,
            int numPointsEnergy,
            double tolerance)
        {
            BandGap = bandGap;
            FermiLevel = fermiLevel;
            Thickness = thickness;
            BuiltInVoltage = builtInVoltage;
            DielectricConstant = dielectricConstant;
            ThermalEmissionPrefactor = thermalEmissionPrefactor;
            Defects = defects;
            NumPointsPosition = numPointsPosition;
            NumPointsEnergy = numPointsEnergy;
            Tolerance = tolerance;

            EnergySpacing = 2 * BandGap / NumPointsEnergy;
            PositionSpacing = Thickness / NumPointsPosition;

            FermiDC = new double[NumPointsPosition];
            PhiDC = new double[NumPointsPosition];
            RhoDC = new double[NumPointsPosition];

            FermiAC = new double[NumPointsPosition];
            PhiAC = new double[NumPointsPosition];
            RhoAC = new double[NumPointsPosition];

            for (int i = 0; i < NumPointsPosition; i++)
            {
                FermiDC[i] = FermiLevel;
                FermiAC[i] = FermiLevel;
            }

            DensityOfStates = new DensityOfStates(this);

            RhoTable = new RhoTable(this);
        }

        public void SolveDC(double appliedVoltage)
        {
            BracketDC(appliedVoltage, out double hi, out double lo);

            double tol = Tolerance;
            double x0 = CalcX0();
            double V = BuiltInVoltage + appliedVoltage;
            while (Math.Abs(PhiDC[NumPointsPosition - 1] / Consts.ElementaryCharge - V) > tol)
            {
                PhiDC[0] = 0.5 * (hi + lo);
                PhiDC[1] = PhiDC[0] * Math.Exp(PositionSpacing / x0);
                RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
                RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);

                CalculateProfileDC(0);

                if (PhiDC[NumPointsPosition - 1] / Consts.ElementaryCharge > V)
                {
                    hi = PhiDC[0];
                }
                else
                {
                    lo = PhiDC[0];
                }
            }
        }

        private void BracketDC(double appliedVoltage, out double hi, out double lo)
        {
            double x0 = CalcX0();
            double V = BuiltInVoltage + appliedVoltage;
            int numPoints = NumPointsPosition;
            PhiDC[0] = Consts.ElementaryCharge * V * Math.Exp(-Thickness / x0);
            PhiDC[1] = PhiDC[0] * Math.Exp(PositionSpacing / x0);
            RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
            RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
            CalculateProfileDC(0);

            hi = 0;
            lo = 0;
            if (PhiDC[numPoints - 1] / Consts.ElementaryCharge < V)
            {
                while (PhiDC[numPoints - 1] / Consts.ElementaryCharge < V)
                {
                    lo = PhiDC[0];
                    PhiDC[0] = 2 * PhiDC[0];
                    PhiDC[1] = PhiDC[0] * Math.Exp(PositionSpacing / x0);
                    RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
                    RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
                    CalculateProfileDC(0);
                }
                hi = 2 * PhiDC[0];
            }
            else
            {
                while (PhiDC[numPoints - 1] / Consts.ElementaryCharge > V)
                {
                    hi = PhiDC[0];
                    PhiDC[0] = 0.5 * PhiDC[0];
                    PhiDC[1] = PhiDC[0] * Math.Exp(PositionSpacing / x0);
                    RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
                    RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
                    CalculateProfileDC(0);
                }
                lo = PhiDC[0];
            }
        }

        private void CalculateProfileDC(int startIndex)
        {
            TotalChargeDC = 0;

            for (int i = startIndex + 1; i < NumPointsPosition - 1; i++)
            {
                PhiDC[i + 1] = 2 * PhiDC[i] - PhiDC[i - 1]
                    + PositionSpacing * PositionSpacing
                    * Consts.ElementaryCharge * RhoDC[i] / DielectricConstant;

                FermiDC[i + 1] = FermiLevel;

                //if (PhiDC[i + 1] - FermiDC[i + 1] > BandGap / 2)
                //{
                //    FermiDC[i + 1] = PhiDC[i + 1] - BandGap / 2;
                //}

                RhoDC[i + 1] = RhoTable.GetRho(FermiDC[i + 1] - PhiDC[i + 1], i + 1);

                PhiDC[i + 1] = NoumerovStep(
                    PhiDC[i], PhiDC[i - 1],
                    Consts.ElementaryCharge * RhoDC[i + 1] / DielectricConstant,
                    Consts.ElementaryCharge * RhoDC[i] / DielectricConstant,
                    Consts.ElementaryCharge * RhoDC[i - 1] / DielectricConstant,
                    PositionSpacing);

                TotalChargeDC += 0.5 * (RhoDC[i] + RhoDC[i - 1]) * PositionSpacing;
            }
        }

        public void SolveAC(double appliedVoltage, double dV, double freq, double T)
        {
            BracketAC(appliedVoltage, dV, freq, T, out double hi, out double lo);

            double tol = Tolerance;
            double x0 = CalcX0();
            double V = BuiltInVoltage + appliedVoltage + dV;
            while (Math.Abs(PhiAC[NumPointsPosition - 1] / Consts.ElementaryCharge - V) > tol)
            {
                PhiAC[0] = 0.5 * (hi + lo);
                PhiAC[1] = PhiAC[0] * Math.Exp(PositionSpacing / x0);
                RhoAC[0] = RhoTable.GetRho(FermiAC[0] - PhiAC[0], 0);
                RhoAC[1] = RhoTable.GetRho(FermiAC[1] - PhiAC[1], 1);

                CalculateProfileAC(0, freq, T);

                if (PhiAC[NumPointsPosition - 1] / Consts.ElementaryCharge > V)
                {
                    hi = PhiAC[0];
                }
                else
                {
                    lo = PhiAC[0];
                }
            }
        }

        private void BracketAC(double appliedVoltage, double dV, double freq, double T, out double hi, out double lo)
        {
            double x0 = CalcX0();
            double V = BuiltInVoltage + appliedVoltage + dV;
            int numPoints = NumPointsPosition;
            PhiAC[0] = Consts.ElementaryCharge * V * Math.Exp(-Thickness / x0);
            PhiAC[1] = PhiAC[0] * Math.Exp(PositionSpacing / x0);
            RhoAC[0] = RhoTable.GetRho(FermiAC[0] - PhiAC[0], 0);
            RhoAC[1] = RhoTable.GetRho(FermiAC[1] - PhiAC[1], 1);
            CalculateProfileAC(0, freq, T);

            hi = 0;
            lo = 0;
            if (PhiAC[numPoints - 1] / Consts.ElementaryCharge < V)
            {
                while (PhiAC[numPoints - 1] / Consts.ElementaryCharge < V)
                {
                    lo = PhiAC[0];
                    PhiAC[0] = 2 * PhiAC[0];
                    PhiAC[1] = PhiAC[0] * Math.Exp(PositionSpacing / x0);
                    RhoAC[0] = RhoTable.GetRho(FermiAC[0] - PhiAC[0], 0);
                    RhoAC[1] = RhoTable.GetRho(FermiAC[1] - PhiAC[1], 1);
                    CalculateProfileAC(0, freq, T);
                }
                hi = 2 * PhiAC[0];
            }
            else
            {
                while (PhiAC[numPoints - 1] / Consts.ElementaryCharge > V)
                {
                    hi = PhiAC[0];
                    PhiAC[0] = 0.5 * PhiAC[0];
                    PhiAC[1] = PhiAC[0] * Math.Exp(PositionSpacing / x0);
                    RhoAC[0] = RhoTable.GetRho(FermiAC[0] - PhiAC[0], 0);
                    RhoAC[1] = RhoTable.GetRho(FermiAC[1] - PhiAC[1], 1);
                    CalculateProfileAC(0, freq, T);
                }
                lo = PhiAC[0];
            }
        }

        private void CalculateProfileAC(int startIndex, double freq, double T)
        {
            double Ee = CalcEe(freq, T);

            TotalChargeAC = 0;

            for (int i = startIndex + 1; i < NumPointsPosition - 1; i++)
            {
                PhiAC[i + 1] = 2 * PhiAC[i] - PhiAC[i - 1]
                    + PositionSpacing * PositionSpacing * Consts.ElementaryCharge * RhoAC[i] / DielectricConstant;

                FermiAC[i + 1] = FermiLevel;

                //if (PhiAC[i + 1] - FermiAC[i + 1] > BandGap / 2)
                //{
                //    FermiAC[i + 1] = PhiAC[i + 1] - BandGap / 2;
                //}

                if (PhiAC[i + 1] < FermiAC[i + 1] + Ee)
                {
                    RhoAC[i + 1] = RhoTable.GetRho(FermiAC[i + 1] - PhiAC[i + 1], i + 1);
                }
                else if (PhiDC[i + 1] < FermiAC[i + 1] + Ee)
                {
                    RhoAC[i + 1] = RhoTable.GetRho(-Ee, i + 1);
                }
                else
                {
                    RhoAC[i + 1] = RhoDC[i + 1];
                }

                PhiAC[i + 1] = NoumerovStep(
                    PhiAC[i], PhiAC[i - 1],
                    Consts.ElementaryCharge * RhoAC[i + 1] / DielectricConstant,
                    Consts.ElementaryCharge * RhoAC[i] / DielectricConstant,
                    Consts.ElementaryCharge * RhoAC[i - 1] / DielectricConstant,
                    PositionSpacing);

                TotalChargeAC += 0.5 * (RhoAC[i] + RhoAC[i - 1]) * PositionSpacing;
            }
        }

        private double CalcX0()
        {
            return Math.Sqrt(DielectricConstant / (Consts.ElementaryCharge * DensityOfStates.GetDensityOfStates(FermiLevel, 0)));
        }

        public double CalcEe(double freq, double T)
        {
            return Consts.BoltzmannConstant * T * Math.Log10(ThermalEmissionPrefactor * T * T / freq);
        }

        private double NoumerovStep(
            double curP, double prevP,
            double nextQ, double curQ, double prevQ,
            double stepSize)
        {
            double stepSizeSq = stepSize * stepSize;

            double nextP = 2 * curP - prevP + stepSizeSq * curQ + (stepSizeSq / 12) * (nextQ + prevQ - 2.0 * curQ);

            return nextP;
        }

        public double MeasureCapacitance(double bias, double dV, double freq, double T)
        {
            SolveDC(bias);
            SolveAC(bias, dV, freq, T);
            double dQ = TotalChargeAC - TotalChargeDC;
            return dQ / dV;
        }

        public DlcpSeries MeasureDlcpSeries(double frequency, double temperature,
            double startBias, double biasStep, int numBias,
            double startAc, double acStep, int numAc)
        {
            DlcpSeries dlcpSeries = new DlcpSeries(temperature, frequency);
            for (int i = 0; i < numBias; i++)
            {
                double bias = startBias + i * biasStep;
                SolveDC(bias);

                double[] dVs = new double[numAc];
                double[] Cs = new double[numAc];
                for (int j = 0; j < numAc; j++)
                {
                    dVs[j] = startAc + j * acStep;
                    Cs[j] = MeasureCapacitance(bias, dVs[j], frequency, temperature);
                }

                DlcpPoint dlcpPoint = new DlcpPoint(bias, dVs, Cs, DielectricConstant);
                dlcpSeries.Add(dlcpPoint);
            }
            return dlcpSeries;
        }
    }
}
