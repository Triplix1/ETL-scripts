using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class FactCovid
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CountryId { get; set; }

    public long DateId { get; set; }

    public long Cases { get; set; }

    public string CaseType { get; set; } = null!;

    public virtual DimCountry Country { get; set; } = null!;

    public virtual DimDate Date { get; set; } = null!;
}
