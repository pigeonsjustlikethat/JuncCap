using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class RhoTable
    {
        public int NumPointsEnergy { get; }
        public int NumPointsPosition { get; }
        public double EnergySpacing { get; }
        public double StartEnergy { get; }

        public double[,] PrecalcRhoTable { get; } 

        public RhoTable(Device device)
        {
            double bandGap = device.BandGap;
            StartEnergy = device.FermiLevel;
            NumPointsPosition = device.NumPointsPosition;
            NumPointsEnergy = device.NumPointsEnergy;
            DensityOfStates DensityOfStates = device.DensityOfStates;

            double positionSpacing = device.PositionSpacing;
            EnergySpacing = (StartEnergy - bandGap) / NumPointsEnergy;
            PrecalcRhoTable = new double[NumPointsPosition, NumPointsEnergy];

            for (int i = 0; i < NumPointsPosition; i++)
            {
                double position = positionSpacing * i;
                for (int j = 1; j < NumPointsEnergy; j++)
                {
                    double energy = StartEnergy + EnergySpacing * j;
                    PrecalcRhoTable[i, j] = PrecalcRhoTable[i, j - 1] + DensityOfStates.GetDensityOfStates(energy, position) * -EnergySpacing;
                }
            }
        }

        public double GetRho(double energy, int positionIndex)
        {
            int energyIndex = (int)((energy - StartEnergy) / EnergySpacing);
            double loEnergy = StartEnergy + energyIndex * EnergySpacing;
            double hiEnergy = StartEnergy + (energyIndex + 1) * EnergySpacing;
            return Utils.Interpolate(energy, loEnergy, hiEnergy, 
                PrecalcRhoTable[positionIndex, energyIndex], 
                PrecalcRhoTable[positionIndex, energyIndex + 1]);
        }
    }
}
