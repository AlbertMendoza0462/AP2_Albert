using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP2_Albert.Migrations
{
    public partial class Correcciondellaveforanea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VerdurasDetalle_Verduras_CompraId",
                table: "VerdurasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_VerdurasDetalle_CompraId",
                table: "VerdurasDetalle");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "VerdurasDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_VerdurasDetalle_VerduraId",
                table: "VerdurasDetalle",
                column: "VerduraId");

            migrationBuilder.AddForeignKey(
                name: "FK_VerdurasDetalle_Verduras_VerduraId",
                table: "VerdurasDetalle",
                column: "VerduraId",
                principalTable: "Verduras",
                principalColumn: "VerduraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VerdurasDetalle_Verduras_VerduraId",
                table: "VerdurasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_VerdurasDetalle_VerduraId",
                table: "VerdurasDetalle");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "VerdurasDetalle",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerdurasDetalle_CompraId",
                table: "VerdurasDetalle",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_VerdurasDetalle_Verduras_CompraId",
                table: "VerdurasDetalle",
                column: "CompraId",
                principalTable: "Verduras",
                principalColumn: "VerduraId");
        }
    }
}
