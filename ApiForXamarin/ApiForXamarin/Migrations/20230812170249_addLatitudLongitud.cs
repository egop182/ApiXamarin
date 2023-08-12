using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiForXamarin.Migrations
{
    /// <inheritdoc />
    public partial class addLatitudLongitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Client",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Client",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Client");
        }
    }
}
