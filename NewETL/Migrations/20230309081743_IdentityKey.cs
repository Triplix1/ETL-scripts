using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewETL.Migrations
{
    /// <inheritdoc />
    public partial class IdentityKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dim_Colors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_colors_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dim_Conditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_conditions_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dim_Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_country_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dim_Date",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<short>(type: "smallint", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_date_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dim_Genders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_genders_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dim_Sallers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_sallers_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage_Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Founded = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stage_brands_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage_CarSales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuyerGender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuyerAge = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NewCar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    MaxSpeed = table.Column<double>(type: "float", nullable: false),
                    SellerNickname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CarGender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stage_carsales_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage_Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stage_countries_id_primary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage_Covid",
                columns: table => new
                {
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cases = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "dim_Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Founded = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dim_brands_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "dim_brands_countryid_foreign",
                        column: x => x.CountryId,
                        principalTable: "dim_Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fact_Covid",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    DateId = table.Column<long>(type: "bigint", nullable: false),
                    Cases = table.Column<long>(type: "bigint", nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fact_covid_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "fact_covid_countryid_foreign",
                        column: x => x.CountryId,
                        principalTable: "dim_Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_covid_dateid_foreign",
                        column: x => x.DateId,
                        principalTable: "dim_Date",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fact_Car_sale",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CarBrandId = table.Column<long>(type: "bigint", nullable: false),
                    SellerId = table.Column<long>(type: "bigint", nullable: false),
                    CarGenderId = table.Column<long>(type: "bigint", nullable: false),
                    BuyerGenderId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CarConditionId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    DateId = table.Column<long>(type: "bigint", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuyerAge = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MaxSpeed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fact_car_sale_id_primary", x => x.Id);
                    table.ForeignKey(
                        name: "fact_car_sale_buyergenderid_foreign",
                        column: x => x.BuyerGenderId,
                        principalTable: "dim_Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_carbrandid_foreign",
                        column: x => x.CarBrandId,
                        principalTable: "dim_Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_carconditionid_foreign",
                        column: x => x.CarConditionId,
                        principalTable: "dim_Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_cargenderid_foreign",
                        column: x => x.CarGenderId,
                        principalTable: "dim_Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_colorid_foreign",
                        column: x => x.ColorId,
                        principalTable: "dim_Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_countryid_foreign",
                        column: x => x.CountryId,
                        principalTable: "dim_Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_dateid_foreign",
                        column: x => x.DateId,
                        principalTable: "dim_Date",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fact_car_sale_sellerid_foreign",
                        column: x => x.SellerId,
                        principalTable: "dim_Sallers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dim_Brands_CountryId",
                table: "dim_Brands",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_BuyerGenderId",
                table: "Fact_Car_sale",
                column: "BuyerGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_CarBrandId",
                table: "Fact_Car_sale",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_CarConditionId",
                table: "Fact_Car_sale",
                column: "CarConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_CarGenderId",
                table: "Fact_Car_sale",
                column: "CarGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_ColorId",
                table: "Fact_Car_sale",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_CountryId",
                table: "Fact_Car_sale",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_DateId",
                table: "Fact_Car_sale",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Car_sale_SellerId",
                table: "Fact_Car_sale",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Covid_CountryId",
                table: "Fact_Covid",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Covid_DateId",
                table: "Fact_Covid",
                column: "DateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fact_Car_sale");

            migrationBuilder.DropTable(
                name: "Fact_Covid");

            migrationBuilder.DropTable(
                name: "Stage_Brands");

            migrationBuilder.DropTable(
                name: "Stage_CarSales");

            migrationBuilder.DropTable(
                name: "Stage_Countries");

            migrationBuilder.DropTable(
                name: "Stage_Covid");

            migrationBuilder.DropTable(
                name: "dim_Genders");

            migrationBuilder.DropTable(
                name: "dim_Brands");

            migrationBuilder.DropTable(
                name: "dim_Conditions");

            migrationBuilder.DropTable(
                name: "dim_Colors");

            migrationBuilder.DropTable(
                name: "dim_Sallers");

            migrationBuilder.DropTable(
                name: "dim_Date");

            migrationBuilder.DropTable(
                name: "dim_Country");
        }
    }
}
