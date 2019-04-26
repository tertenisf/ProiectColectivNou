using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectColectiv.Migrations
{
    public partial class Double : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitudine",
                table: "Parkings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitudine",
                table: "Parkings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitudine",
                table: "Parkings",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Latitudine",
                table: "Parkings",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
