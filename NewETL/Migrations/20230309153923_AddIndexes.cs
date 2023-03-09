using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewETL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_dim_Sallers_Name",
                table: "dim_Sallers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_dim_Date_Year_Month_Day",
                table: "dim_Date",
                columns: new[] { "Year", "Month", "Day" });

            migrationBuilder.CreateIndex(
                name: "IX_dim_Country_Name",
                table: "dim_Country",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_dim_Colors_ColorName",
                table: "dim_Colors",
                column: "ColorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_dim_Sallers_Name",
                table: "dim_Sallers");

            migrationBuilder.DropIndex(
                name: "IX_dim_Date_Year_Month_Day",
                table: "dim_Date");

            migrationBuilder.DropIndex(
                name: "IX_dim_Country_Name",
                table: "dim_Country");

            migrationBuilder.DropIndex(
                name: "IX_dim_Colors_ColorName",
                table: "dim_Colors");
        }
    }
}
