using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class FactCarSale
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CarBrandId { get; set; }

    public long SellerId { get; set; }

    public long CarGenderId { get; set; }

    public long BuyerGenderId { get; set; }

    public long CountryId { get; set; }

    public long CarConditionId { get; set; }

    public long ColorId { get; set; }

    public long DateId { get; set; }

    public string CarModel { get; set; } = null!;

    public int BuyerAge { get; set; }

    public double Price { get; set; }

    public double MaxSpeed { get; set; }

    public virtual DimGender BuyerGender { get; set; } = null!;

    public virtual DimBrand CarBrand { get; set; } = null!;

    public virtual DimCondition CarCondition { get; set; } = null!;

    public virtual DimGender CarGender { get; set; } = null!;

    public virtual DimColor Color { get; set; } = null!;

    public virtual DimCountry Country { get; set; } = null!;

    public virtual DimDate Date { get; set; } = null!;

    public virtual DimSaller Seller { get; set; } = null!;
}
