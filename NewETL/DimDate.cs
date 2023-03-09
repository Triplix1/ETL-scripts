using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimDate
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public int Year { get; set; }

    public short Month { get; set; }

    public short Day { get; set; }

    public virtual ICollection<FactCarSale> FactCarSales { get; } = new List<FactCarSale>();

    public virtual ICollection<FactCovid> FactCovids { get; } = new List<FactCovid>();
}
