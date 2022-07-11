using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verduras",
                columns: table => new
                {
                    VerduraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verduras", x => x.VerduraId);
                });

            migrationBuilder.CreateTable(
                name: "Vitaminas",
                columns: table => new
                {
                    VitaminaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadDeMedida = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitaminas", x => x.VitaminaId);
                });

            migrationBuilder.CreateTable(
                name: "VerdurasDetalle",
                columns: table => new
                {
                    VerdurasDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VerduraId = table.Column<int>(type: "INTEGER", nullable: false),
                    VitaminaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerdurasDetalle", x => x.VerdurasDetalleId);
                    table.ForeignKey(
                        name: "FK_VerdurasDetalle_Verduras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Verduras",
                        principalColumn: "VerduraId");
                });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 1, "Vitamina A", "Miligramos" });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 2, "Vitamina B", "Microgramos" });

            migrationBuilder.CreateIndex(
                name: "IX_VerdurasDetalle_CompraId",
                table: "VerdurasDetalle",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerdurasDetalle");

            migrationBuilder.DropTable(
                name: "Vitaminas");

            migrationBuilder.DropTable(
                name: "Verduras");
        }
    }
}
