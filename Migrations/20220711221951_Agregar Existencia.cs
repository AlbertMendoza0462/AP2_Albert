using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class AgregarExistencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnidadDeMedida",
                table: "Vitaminas",
                newName: "UnidadMedida");

            migrationBuilder.AddColumn<int>(
                name: "Existencia",
                table: "Vitaminas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Verduras",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Vitaminas");

            migrationBuilder.RenameColumn(
                name: "UnidadMedida",
                table: "Vitaminas",
                newName: "UnidadDeMedida");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Verduras",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
