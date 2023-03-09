using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewETL
{
    internal class ColorEqualityComparer : IEqualityComparer<DimColor>
    {
        public bool Equals(DimColor? x, DimColor? y)
        {
            return x.ColorName == y.ColorName;
        }

        public int GetHashCode([DisallowNull] DimColor obj)
        {
            return obj.ColorName.GetHashCode();
        }
    }
}
