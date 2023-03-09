using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimBrand
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CountryId { get; set; }

    public string Name { get; set; } = null!;

    public long Founded { get; set; }

    public virtual DimCountry Country { get; set; } = null!;

    public virtual ICollection<FactCarSale> FactCarSales { get; } = new List<FactCarSale>();
}
