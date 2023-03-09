using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewETL;

public partial class DimGender
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<FactCarSale> FactCarSaleBuyerGenders { get; } = new List<FactCarSale>();

    public virtual ICollection<FactCarSale> FactCarSaleCarGenders { get; } = new List<FactCarSale>();
}
