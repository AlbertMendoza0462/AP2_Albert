using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class ActializarModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                column: "Existencia",
                value: 0);
        }
    }
}
