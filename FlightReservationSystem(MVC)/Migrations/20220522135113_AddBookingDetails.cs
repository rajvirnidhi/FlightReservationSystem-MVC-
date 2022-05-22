using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem_MVC_.Migrations
{
    public partial class AddBookingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "cost",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "days",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "destination",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flightid",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "hours",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "seats",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "source",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "cost",
                table: "User");

            migrationBuilder.DropColumn(
                name: "days",
                table: "User");

            migrationBuilder.DropColumn(
                name: "destination",
                table: "User");

            migrationBuilder.DropColumn(
                name: "flightid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "hours",
                table: "User");

            migrationBuilder.DropColumn(
                name: "name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "seats",
                table: "User");

            migrationBuilder.DropColumn(
                name: "source",
                table: "User");
        }
    }
}
