using Microsoft.EntityFrameworkCore.Migrations;

namespace FioreolloBack.Migrations
{
    public partial class settingsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParallaxImg",
                table: "Settings",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketIcon",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceUrl",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstaURL",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchIcon",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketIcon",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FaceUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InstaURL",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SearchIcon",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "ParallaxImg",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
