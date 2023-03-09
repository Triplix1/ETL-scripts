using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimColor
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<FactCarSale> FactCarSales { get; } = new List<FactCarSale>();
}
