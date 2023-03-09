using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewETL;

public partial class AdisContext : DbContext
{
    public AdisContext()
    {
    }

    public AdisContext(DbContextOptions<AdisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimBrand> DimBrands { get; set; }

    public virtual DbSet<DimColor> DimColors { get; set; }

    public virtual DbSet<DimCondition> DimConditions { get; set; }

    public virtual DbSet<DimCountry> DimCountries { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimGender> DimGenders { get; set; }

    public virtual DbSet<DimSaller> DimSallers { get; set; }

    public virtual DbSet<FactCarSale> FactCarSales { get; set; }

    public virtual DbSet<FactCovid> FactCovids { get; set; }

    public virtual DbSet<StageBrand> StageBrands { get; set; }

    public virtual DbSet<StageCarSale> StageCarSales { get; set; }

    public virtual DbSet<StageCountry> StageCountries { get; set; }

    public virtual DbSet<StageCovid> StageCovids { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-60TE6OA\\SPOCK_SQL_2019;Database=ADIS;Trusted_Connection=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_brands_id_primary");

            entity.ToTable("dim_Brands");

            entity.HasIndex(e => e.CountryId, "IX_dim_Brands_CountryId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Country).WithMany(p => p.DimBrands)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dim_brands_countryid_foreign");
        });

        modelBuilder.Entity<DimColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_colors_id_primary");

            entity.ToTable("dim_Colors");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ColorName).HasMaxLength(255);

            entity.HasIndex(e => e.ColorName);
        });

        modelBuilder.Entity<DimCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_conditions_id_primary");

            entity.ToTable("dim_Conditions");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Condition).HasMaxLength(255);
        });

        modelBuilder.Entity<DimCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_country_id_primary");

            entity.ToTable("dim_Country");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasIndex(e => e.Name);
        });

        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_date_id_primary");

            entity.ToTable("dim_Date");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasIndex(e => new {e.Year, e.Month, e.Day});
        });

        modelBuilder.Entity<DimGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_genders_id_primary");

            entity.ToTable("dim_Genders");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Gender).HasMaxLength(255);
        });

        modelBuilder.Entity<DimSaller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dim_sallers_id_primary");

            entity.ToTable("dim_Sallers");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasIndex(e => e.Name);

        });

        modelBuilder.Entity<FactCarSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fact_car_sale_id_primary");

            entity.ToTable("Fact_Car_sale");

            entity.HasIndex(e => e.BuyerGenderId, "IX_Fact_Car_sale_BuyerGenderId");

            entity.HasIndex(e => e.CarBrandId, "IX_Fact_Car_sale_CarBrandId");

            entity.HasIndex(e => e.CarConditionId, "IX_Fact_Car_sale_CarConditionId");

            entity.HasIndex(e => e.CarGenderId, "IX_Fact_Car_sale_CarGenderId");

            entity.HasIndex(e => e.ColorId, "IX_Fact_Car_sale_ColorId");

            entity.HasIndex(e => e.CountryId, "IX_Fact_Car_sale_CountryId");

            entity.HasIndex(e => e.DateId, "IX_Fact_Car_sale_DateId");

            entity.HasIndex(e => e.SellerId, "IX_Fact_Car_sale_SellerId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CarModel).HasMaxLength(255);

            entity.HasOne(d => d.BuyerGender).WithMany(p => p.FactCarSaleBuyerGenders)
                .HasForeignKey(d => d.BuyerGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_buyergenderid_foreign");

            entity.HasOne(d => d.CarBrand).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.CarBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_carbrandid_foreign");

            entity.HasOne(d => d.CarCondition).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.CarConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_carconditionid_foreign");

            entity.HasOne(d => d.CarGender).WithMany(p => p.FactCarSaleCarGenders)
                .HasForeignKey(d => d.CarGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_cargenderid_foreign");

            entity.HasOne(d => d.Color).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_colorid_foreign");

            entity.HasOne(d => d.Country).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_countryid_foreign");

            entity.HasOne(d => d.Date).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.DateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_dateid_foreign");

            entity.HasOne(d => d.Seller).WithMany(p => p.FactCarSales)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_car_sale_sellerid_foreign");
        });

        modelBuilder.Entity<FactCovid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fact_covid_id_primary");

            entity.ToTable("Fact_Covid");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CaseType).HasMaxLength(255);

            entity.HasOne(d => d.Country).WithMany(p => p.FactCovids)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_covid_countryid_foreign");

            entity.HasOne(d => d.Date).WithMany(p => p.FactCovids)
                .HasForeignKey(d => d.DateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_covid_dateid_foreign");
        });

        modelBuilder.Entity<StageBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stage_brands_id_primary");

            entity.ToTable("Stage_Brands");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<StageCarSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stage_carsales_id_primary");

            entity.ToTable("Stage_CarSales");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BuyerGender).HasMaxLength(255);
            entity.Property(e => e.CarGender).HasMaxLength(255);
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Make).HasMaxLength(255);
            entity.Property(e => e.Model).HasMaxLength(255);
            entity.Property(e => e.NewCar).HasMaxLength(255);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.SellerNickname).HasMaxLength(255);
        });

        modelBuilder.Entity<StageCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stage_countries_id_primary");

            entity.ToTable("Stage_Countries");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<StageCovid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage_Covid");

            entity.Property(e => e.CaseType).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
