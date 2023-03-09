using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimCondition
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Condition { get; set; } = null!;

    public virtual ICollection<FactCarSale> FactCarSales { get; } = new List<FactCarSale>();
}
