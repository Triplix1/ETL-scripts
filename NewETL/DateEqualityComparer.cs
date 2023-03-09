using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewETL
{
    internal class DateEqualityComparer : IEqualityComparer<DimDate>
    {
        public bool Equals(DimDate? x, DimDate? y)
        {
            return x.Year == y.Year && x.Month == y.Month && x.Day == y.Day;
        }

        public int GetHashCode([DisallowNull] DimDate obj)
        {
            return obj.Year ^ obj.Month ^ obj.Day;
        }
    }
}
