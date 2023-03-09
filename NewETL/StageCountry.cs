using System;
using System.Collections.Generic;

namespace NewETL;

public partial class StageCountry
{
    public long Id { get; set; }

    public long Population { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;
}
