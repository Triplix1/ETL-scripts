CREATE TABLE "Stage_Brands"(
    "id" BIGINT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL,
    "Country" NVARCHAR(255) NOT NULL,
    "Founded" BIGINT NOT NULL
);
ALTER TABLE
    "Stage_Brands" ADD CONSTRAINT "stage_brands_id_primary" PRIMARY KEY("id");
CREATE TABLE "Stage_Countries"(
    "id" BIGINT NOT NULL,
    "Population" BIGINT NOT NULL,
    "Name" BIGINT NOT NULL,
    "CountryCode" BIGINT NOT NULL
);
ALTER TABLE
    "Stage_Countries" ADD CONSTRAINT "stage_countries_id_primary" PRIMARY KEY("id");
CREATE TABLE "Stage_CarSales"(
    "id" BIGINT NOT NULL,
    "Make" NVARCHAR(255) NOT NULL,
    "Model" NVARCHAR(255) NOT NULL,
    "BuyerGender" NVARCHAR(6) NOT NULL,
    "BuyerAge" INT NOT NULL,
    "Country" NVARCHAR(255) NOT NULL,
    "Color" NVARCHAR(255) NOT NULL,
    "NewCar" NVARCHAR(255) NOT NULL,
    "PurchaseDate" DATETIME NOT NULL,
    "SalePrice" FLOAT NOT NULL,
    "MaxSpeed" FLOAT NOT NULL,
    "SellerNickname" NVARCHAR(255) NOT NULL,
    "CarGender" NVARCHAR(6) NOT NULL
);
ALTER TABLE
    "Stage_CarSales" ADD CONSTRAINT "stage_carsales_id_primary" PRIMARY KEY("id");
CREATE TABLE "Stage_Covid"(
    "Country" NVARCHAR(255) NOT NULL,
    "CaseType" NVARCHAR(255) NOT NULL,
    "Cases" BIGINT NOT NULL,
    "Date" DATETIME NOT NULL
);