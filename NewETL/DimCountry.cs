using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimCountry
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Population { get; set; }

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<DimBrand> DimBrands { get; } = new List<DimBrand>();

    public virtual ICollection<FactCarSale> FactCarSales { get; } = new List<FactCarSale>();

    public virtual ICollection<FactCovid> FactCovids { get; } = new List<FactCovid>();
}
