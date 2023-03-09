using System;
using System.Collections.Generic;

namespace NewETL;

public partial class StageCovid
{
    public string Country { get; set; } = null!;

    public string CaseType { get; set; } = null!;

    public long Cases { get; set; }

    public DateTime Date { get; set; }
}
