using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MovieShop_.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "RentalDetails");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RentalDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "RentalDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
