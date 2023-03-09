using System;
using System.Collections.Generic;

namespace NewETL;

public partial class StageBrand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public long Founded { get; set; }
}
