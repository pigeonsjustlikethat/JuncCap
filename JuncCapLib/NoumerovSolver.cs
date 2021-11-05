//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JuncCapLib
//{
//    public static class NoumerovSolver
//    {
//        //public int NumPoints { get; }
//        //public double BandGap { get; }
//        //public double StepSize { get; }
//        //public double Epsilon { get; }
//        //public double FermiLevel { get; }
//        //public double Thickness { get; }
//        //public double ThermalEmissionPrefactor { get; }

//        //public double[] FermiDC { get; }
//        //public double[] PhiDC { get; }
//        //public double[] RhoDC { get; }

//        //public double[] FermiAC { get; }
//        //public double[] PhiAC { get; }
//        //public double[] RhoAC { get; }

//        //public double lo;
//        //public double hi;

//        //DensityOfStates DensityOfStates { get; }

//        //RhoTable RhoTable { get; }
        
//        //public NoumerovSolver(Device device)
//        //{
//        //    NumPoints = device.NumPointsPosition;
//        //    StepSize = device.PositionSpacing;
//        //    Epsilon = device.DielectricConstant;
//        //    BandGap = device.BandGap;
//        //    FermiLevel = device.FermiLevel;
//        //    Thickness = device.Thickness;
//        //    ThermalEmissionPrefactor = device.ThermalEmissionPrefactor;

//        //    FermiDC = new double[NumPoints];
//        //    PhiDC = new double[NumPoints];
//        //    RhoDC = new double[NumPoints];

//        //    FermiAC = new double[NumPoints];
//        //    PhiAC = new double[NumPoints];
//        //    RhoAC = new double[NumPoints];

//        //    for (int i = 0; i < NumPoints; i++)
//        //    {
//        //        FermiDC[i] = device.FermiLevel;
//        //        FermiAC[i] = device.FermiLevel;
//        //    }

//        //    DensityOfStates = device.DensityOfStates;
//        //    RhoTable = device.RhoTable;
//        //}

//        public static void BracketDC(Device device, double appliedVoltage)
//        {
//            double x0 = CalcX0(device);
//            double V = device.BuiltInVoltage + appliedVoltage;
//            int numPoints = device.NumPointsPosition;
//            PhiDC[0] = Consts.ElementaryCharge * V * Math.Exp(-device.Thickness / x0);
//            PhiDC[1] = PhiDC[0] * Math.Exp(device.PositionSpacing/ x0);
//            RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
//            RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
//            CalculateProfileDC(0);

//            if (PhiDC[numPoints - 1] / Consts.ElementaryCharge < V)
//            {
//                while (PhiDC[numPoints - 1] / Consts.ElementaryCharge < V)
//                {
//                    lo = PhiDC[0];
//                    PhiDC[0] = 2 * PhiDC[0];
//                    PhiDC[1] = PhiDC[0] * Math.Exp(StepSize / x0);
//                    RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
//                    RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
//                    CalculateProfileDC(0);
//                }
//                hi = 2 * PhiDC[0];
//            }
//            else
//            {
//                while (PhiDC[numPoints - 1] / Consts.ElementaryCharge > V)
//                {
//                    hi = PhiDC[0];
//                    PhiDC[0] = 0.5 * PhiDC[0];
//                    PhiDC[1] = PhiDC[0] * Math.Exp(StepSize / x0);
//                    RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
//                    RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);
//                    CalculateProfileDC(0);
//                }
//                lo = PhiDC[0];
//            }
//        }

//        public void SolveDC(Device device, double appliedVoltage)
//        {
//            BracketDC();

//            double tol = 1e-2;
//            double x0 = CalcX0();
//            double Voltage = 1;
//            while (Math.Abs(PhiDC[NumPoints -1] / Consts.ElementaryCharge - Voltage) > tol)
//            {
//                PhiDC[0] = 0.5 * (hi + lo);
//                PhiDC[1] = PhiDC[0] * Math.Exp(StepSize / x0);
//                RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
//                RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);

//                CalculateProfileDC(0);

//                if (PhiDC[NumPoints - 1] / Consts.ElementaryCharge > Voltage)
//                {
//                    hi = PhiDC[0];
//                }
//                else
//                {
//                    lo = PhiDC[0];
//                }
//            }
//        }

//        public void SolveAC()
//        {
//            BracketDC();

//            double tol = 1e-2;
//            double x0 = CalcX0();
//            double Voltage = 1;
//            while (Math.Abs(PhiDC[NumPoints - 1] / Consts.ElementaryCharge - Voltage) > tol)
//            {
//                PhiDC[0] = 0.5 * (hi + lo);
//                PhiDC[1] = PhiDC[0] * Math.Exp(StepSize / x0);
//                RhoDC[0] = RhoTable.GetRho(FermiDC[0] - PhiDC[0], 0);
//                RhoDC[1] = RhoTable.GetRho(FermiDC[1] - PhiDC[1], 1);

//                CalculateProfileDC(0);

//                if (PhiDC[NumPoints - 1] / Consts.ElementaryCharge > Voltage)
//                {
//                    hi = PhiDC[0];
//                }
//                else
//                {
//                    lo = PhiDC[0];
//                }
//            }
//        }

//        private void CalculateProfileDC(int startIndex)
//        {
//            for (int i = startIndex + 1; i < NumPoints - 1; i++)
//            {
//                PhiDC[i + 1] = 2 * PhiDC[i] - PhiDC[i - 1] 
//                    + StepSize * StepSize * Consts.ElementaryCharge * RhoDC[i] / Epsilon;

//                FermiDC[i + 1] = FermiLevel;

//                if (PhiDC[i + 1] - FermiDC[i + 1] > BandGap / 2)
//                {
//                    FermiDC[i + 1] = PhiDC[i + 1] - BandGap / 2;
//                }

//                RhoDC[i + 1] = RhoTable.GetRho(FermiDC[i + 1] - PhiDC[i + 1], i + 1);

//                PhiDC[i + 1] = NoumerovStep(
//                    PhiDC[i], PhiDC[i - 1],
//                    Consts.ElementaryCharge * RhoDC[i + 1] / Epsilon,
//                    Consts.ElementaryCharge * RhoDC[i] / Epsilon,
//                    Consts.ElementaryCharge * RhoDC[i - 1] / Epsilon, 
//                    StepSize);
//            }
//        }

//        private void CalculateProfileAC(int startIndex, double freq, double T)
//        {
//            double Ee = CalcEe(freq, T, ThermalEmissionPrefactor);

//            for (int i = startIndex + 1; i < NumPoints - 1; i++)
//            {
//                PhiAC[i + 1] = 2 * PhiAC[i] - PhiAC[i - 1]
//                    + StepSize * StepSize * Consts.ElementaryCharge * RhoAC[i] / Epsilon;

//                FermiAC[i + 1] = FermiLevel;

//                if (PhiAC[i + 1] - FermiAC[i + 1] > BandGap / 2)
//                {
//                    FermiAC[i + 1] = PhiAC[i + 1] - BandGap / 2;
//                }

//                if (PhiAC[i + 1] < FermiAC[i + 1] + Ee)
//                {
//                    RhoAC[i + 1] = RhoTable.GetRho(FermiAC[i + 1] - PhiAC[i + 1], i + 1);
//                }
//                else if (PhiDC[i + 1] < FermiAC[i + 1] + Ee)
//                {
//                    RhoAC[i + 1] = RhoTable.GetRho(-Ee, i + 1);
//                }
//                else
//                {
//                    RhoAC[i + 1] = RhoDC[i + 1];
//                }

//                PhiAC[i + 1] = NoumerovStep(
//                    PhiAC[i], PhiAC[i - 1],
//                    Consts.ElementaryCharge * RhoAC[i + 1] / Epsilon,
//                    Consts.ElementaryCharge * RhoAC[i] / Epsilon,
//                    Consts.ElementaryCharge * RhoAC[i - 1] / Epsilon,
//                    StepSize);
//            }
//        }

//        private static double CalcX0(Device device)
//        {
//            return Math.Sqrt(device.DielectricConstant / (Consts.ElementaryCharge * device.DensityOfStates.GetDensityOfStates(device.FermiLevel, 0)));
//        }

//        private double CalcEe(double freq, double T, double nu)
//        {
//            return Consts.BoltzmannConstant * T * Math.Log10(nu / freq);
//        }

//        private double NoumerovStep(
//            double curP, double prevP, 
//            double nextQ, double curQ, double prevQ,
//            double stepSize)
//        {
//            double stepSizeSq = stepSize * stepSize;

//            double nextP = 2 * curP - prevP + stepSizeSq * curQ + (stepSizeSq / 12) * (nextQ + prevQ - 2.0 * curQ);

//            return nextP;
//        }
//    }
//}
