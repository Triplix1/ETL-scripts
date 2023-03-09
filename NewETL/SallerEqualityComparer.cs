using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewETL
{
    internal class SallerEqualityComparer : IEqualityComparer<DimSaller>
    {
        public bool Equals(DimSaller? x, DimSaller? y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] DimSaller obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
