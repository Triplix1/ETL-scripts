// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewETL;

#nullable disable

namespace NewETL.Migrations
{
    [DbContext(typeof(AdisContext))]
    partial class AdisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewETL.DimBrand", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<long>("Founded")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("dim_brands_id_primary");

                    b.HasIndex(new[] { "CountryId" }, "IX_dim_Brands_CountryId");

                    b.ToTable("dim_Brands", (string)null);
                });

            modelBuilder.Entity("NewETL.DimColor", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("dim_colors_id_primary");

                    b.HasIndex("ColorName");

                    b.ToTable("dim_Colors", (string)null);
                });

            modelBuilder.Entity("NewETL.DimCondition", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("dim_conditions_id_primary");

                    b.ToTable("dim_Conditions", (string)null);
                });

            modelBuilder.Entity("NewETL.DimCountry", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("dim_country_id_primary");

                    b.HasIndex("Name");

                    b.ToTable("dim_Country", (string)null);
                });

            modelBuilder.Entity("NewETL.DimDate", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<short>("Day")
                        .HasColumnType("smallint");

                    b.Property<short>("Month")
                        .HasColumnType("smallint");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("dim_date_id_primary");

                    b.HasIndex("Year", "Month", "Day");

                    b.ToTable("dim_Date", (string)null);
                });

            modelBuilder.Entity("NewETL.DimGender", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("dim_genders_id_primary");

                    b.ToTable("dim_Genders", (string)null);
                });

            modelBuilder.Entity("NewETL.DimSaller", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("dim_sallers_id_primary");

                    b.HasIndex("Name");

                    b.ToTable("dim_Sallers", (string)null);
                });

            modelBuilder.Entity("NewETL.FactCarSale", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("BuyerAge")
                        .HasColumnType("int");

                    b.Property<long>("BuyerGenderId")
                        .HasColumnType("bigint");

                    b.Property<long>("CarBrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("CarConditionId")
                        .HasColumnType("bigint");

                    b.Property<long>("CarGenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<long>("DateId")
                        .HasColumnType("bigint");

                    b.Property<double>("MaxSpeed")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("SellerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("fact_car_sale_id_primary");

                    b.HasIndex(new[] { "BuyerGenderId" }, "IX_Fact_Car_sale_BuyerGenderId");

                    b.HasIndex(new[] { "CarBrandId" }, "IX_Fact_Car_sale_CarBrandId");

                    b.HasIndex(new[] { "CarConditionId" }, "IX_Fact_Car_sale_CarConditionId");

                    b.HasIndex(new[] { "CarGenderId" }, "IX_Fact_Car_sale_CarGenderId");

                    b.HasIndex(new[] { "ColorId" }, "IX_Fact_Car_sale_ColorId");

                    b.HasIndex(new[] { "CountryId" }, "IX_Fact_Car_sale_CountryId");

                    b.HasIndex(new[] { "DateId" }, "IX_Fact_Car_sale_DateId");

                    b.HasIndex(new[] { "SellerId" }, "IX_Fact_Car_sale_SellerId");

                    b.ToTable("Fact_Car_sale", (string)null);
                });

            modelBuilder.Entity("NewETL.FactCovid", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CaseType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Cases")
                        .HasColumnType("bigint");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<long>("DateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("fact_covid_id_primary");

                    b.HasIndex("CountryId");

                    b.HasIndex("DateId");

                    b.ToTable("Fact_Covid", (string)null);
                });

            modelBuilder.Entity("NewETL.StageBrand", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Founded")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("stage_brands_id_primary");

                    b.ToTable("Stage_Brands", (string)null);
                });

            modelBuilder.Entity("NewETL.StageCarSale", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("BuyerAge")
                        .HasColumnType("int");

                    b.Property<string>("BuyerGender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CarGender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("MaxSpeed")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NewCar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.Property<string>("SellerNickname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("stage_carsales_id_primary");

                    b.ToTable("Stage_CarSales", (string)null);
                });

            modelBuilder.Entity("NewETL.StageCountry", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("stage_countries_id_primary");

                    b.ToTable("Stage_Countries", (string)null);
                });

            modelBuilder.Entity("NewETL.StageCovid", b =>
                {
                    b.Property<string>("CaseType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Cases")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.ToTable("Stage_Covid", (string)null);
                });

            modelBuilder.Entity("NewETL.DimBrand", b =>
                {
                    b.HasOne("NewETL.DimCountry", "Country")
                        .WithMany("DimBrands")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("dim_brands_countryid_foreign");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("NewETL.FactCarSale", b =>
                {
                    b.HasOne("NewETL.DimGender", "BuyerGender")
                        .WithMany("FactCarSaleBuyerGenders")
                        .HasForeignKey("BuyerGenderId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_buyergenderid_foreign");

                    b.HasOne("NewETL.DimBrand", "CarBrand")
                        .WithMany("FactCarSales")
                        .HasForeignKey("CarBrandId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_carbrandid_foreign");

                    b.HasOne("NewETL.DimCondition", "CarCondition")
                        .WithMany("FactCarSales")
                        .HasForeignKey("CarConditionId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_carconditionid_foreign");

                    b.HasOne("NewETL.DimGender", "CarGender")
                        .WithMany("FactCarSaleCarGenders")
                        .HasForeignKey("CarGenderId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_cargenderid_foreign");

                    b.HasOne("NewETL.DimColor", "Color")
                        .WithMany("FactCarSales")
                        .HasForeignKey("ColorId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_colorid_foreign");

                    b.HasOne("NewETL.DimCountry", "Country")
                        .WithMany("FactCarSales")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_countryid_foreign");

                    b.HasOne("NewETL.DimDate", "Date")
                        .WithMany("FactCarSales")
                        .HasForeignKey("DateId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_dateid_foreign");

                    b.HasOne("NewETL.DimSaller", "Seller")
                        .WithMany("FactCarSales")
                        .HasForeignKey("SellerId")
                        .IsRequired()
                        .HasConstraintName("fact_car_sale_sellerid_foreign");

                    b.Navigation("BuyerGender");

                    b.Navigation("CarBrand");

                    b.Navigation("CarCondition");

                    b.Navigation("CarGender");

                    b.Navigation("Color");

                    b.Navigation("Country");

                    b.Navigation("Date");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("NewETL.FactCovid", b =>
                {
                    b.HasOne("NewETL.DimCountry", "Country")
                        .WithMany("FactCovids")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("fact_covid_countryid_foreign");

                    b.HasOne("NewETL.DimDate", "Date")
                        .WithMany("FactCovids")
                        .HasForeignKey("DateId")
                        .IsRequired()
                        .HasConstraintName("fact_covid_dateid_foreign");

                    b.Navigation("Country");

                    b.Navigation("Date");
                });

            modelBuilder.Entity("NewETL.DimBrand", b =>
                {
                    b.Navigation("FactCarSales");
                });

            modelBuilder.Entity("NewETL.DimColor", b =>
                {
                    b.Navigation("FactCarSales");
                });

            modelBuilder.Entity("NewETL.DimCondition", b =>
                {
                    b.Navigation("FactCarSales");
                });

            modelBuilder.Entity("NewETL.DimCountry", b =>
                {
                    b.Navigation("DimBrands");

                    b.Navigation("FactCarSales");

                    b.Navigation("FactCovids");
                });

            modelBuilder.Entity("NewETL.DimDate", b =>
                {
                    b.Navigation("FactCarSales");

                    b.Navigation("FactCovids");
                });

            modelBuilder.Entity("NewETL.DimGender", b =>
                {
                    b.Navigation("FactCarSaleBuyerGenders");

                    b.Navigation("FactCarSaleCarGenders");
                });

            modelBuilder.Entity("NewETL.DimSaller", b =>
                {
                    b.Navigation("FactCarSales");
                });
#pragma warning restore 612, 618
        }
    }
}
