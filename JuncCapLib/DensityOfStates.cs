using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public class DensityOfStates
    {
        public double StartEnergy { get; }
        public double EnergySpacing { get; }
        public double PositionSpacing { get; }
        public int NumPointsPosition { get; }
        public int NumPointsEnergy { get; }

        public double[,] Dos { get; }
        public List<Defect> Defects { get; }

        public DensityOfStates(Device device)
        {
            Defects = device.Defects;
            StartEnergy = -2 * device.BandGap;
            NumPointsEnergy = device.NumPointsEnergy;
            NumPointsPosition = device.NumPointsPosition;
            EnergySpacing = device.EnergySpacing;
            PositionSpacing = device.PositionSpacing;
            Dos = new double[NumPointsPosition, NumPointsEnergy];

            for (int i = 0; i < NumPointsPosition; i++)
            {
                double position = i * PositionSpacing;
                for (int j = 0; j < NumPointsEnergy; j++)
                {
                    double energy = StartEnergy + j * EnergySpacing;
                    foreach (Defect defect in Defects)
                    {
                        Dos[i, j] += defect.GetDensity(energy, position);
                    }
                }
            }
        }

        public double GetDensityOfStates(double energy, double position)
        {
            int energyIndex = (int)((energy - StartEnergy) / EnergySpacing);
            double loEnergy = StartEnergy + energyIndex * EnergySpacing;
            double hiEnergy = StartEnergy + (energyIndex + 1) * EnergySpacing;

            int loPositionIndex = (int)(position / PositionSpacing);
            int hiPositionIndex = loPositionIndex + 1;
            double loPosition = loPositionIndex * PositionSpacing;
            double hiPosition = hiPositionIndex * PositionSpacing;

            if (hiPositionIndex == NumPointsPosition)
            {
                hiPositionIndex -= 1;
            }

            return Utils.BilinearInterpolate(
                position, loPosition, hiPosition,
                energy, loEnergy, hiEnergy,
                Dos[loPositionIndex, energyIndex], Dos[loPositionIndex, energyIndex + 1],
                Dos[hiPositionIndex, energyIndex], Dos[hiPositionIndex, energyIndex + 1]);
        }
    }
}
