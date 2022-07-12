using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class Existenciaahoraesdouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Existencia",
                table: "Vitaminas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                column: "Existencia",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                column: "Existencia",
                value: 50.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Existencia",
                table: "Vitaminas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                column: "Existencia",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                column: "Existencia",
                value: 50);
        }
    }
}
