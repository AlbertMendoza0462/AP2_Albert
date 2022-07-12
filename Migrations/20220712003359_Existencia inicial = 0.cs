using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class Existenciainicial0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                column: "Existencia",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                column: "Existencia",
                value: 0.0);

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "Existencia", "UnidadMedida" },
                values: new object[] { 3, "Vitamina C", 0.0, "Miligramos" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "Existencia", "UnidadMedida" },
                values: new object[] { 4, "Vitamina D", 0.0, "Microgramos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 4);

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
    }
}
