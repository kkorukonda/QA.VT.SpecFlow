using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VT.SpecFlow.Strategies.FormActionStrategies
{
    internal enum IfsDateFilterType
    {
        Invalid = -1,
        Single = 0,
        DateRange = 1,
        During = 2,
        InRange = 3,
    }
}
