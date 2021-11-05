using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuncCapLib
{
    public abstract class Defect
    {
        public abstract double GetDensity(double energy, double position);
    }
}
