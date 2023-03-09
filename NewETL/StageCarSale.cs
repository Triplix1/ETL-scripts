using System;
using System.Collections.Generic;

namespace NewETL;

public partial class StageCarSale
{
    public long Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string BuyerGender { get; set; } = null!;

    public int BuyerAge { get; set; }

    public string Country { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string NewCar { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public double SalePrice { get; set; }

    public double MaxSpeed { get; set; }

    public string SellerNickname { get; set; } = null!;

    public string CarGender { get; set; } = null!;
}
