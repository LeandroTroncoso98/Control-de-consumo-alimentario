using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaConsumoDiarioMMAlimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Potacio",
                table: "Alimento",
                newName: "Potasio");

            migrationBuilder.CreateTable(
                name: "ConsumoDiario",
                columns: table => new
                {
                    ConsumoDiario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaloriasTotales = table.Column<float>(type: "real", nullable: false),
                    CarbohidratosTotales = table.Column<float>(type: "real", nullable: false),
                    ProteinasTotales = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    SodioTotal = table.Column<float>(type: "real", nullable: false),
                    PotasioTotal = table.Column<float>(type: "real", nullable: false),
                    FibrasTotales = table.Column<float>(type: "real", nullable: false),
                    AzucarTotal = table.Column<float>(type: "real", nullable: false),
                    VitaminaATotal = table.Column<float>(type: "real", nullable: false),
                    VitaminaCTotal = table.Column<float>(type: "real", nullable: false),
                    CalcioTotal = table.Column<float>(type: "real", nullable: false),
                    HierroTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDiario", x => x.ConsumoDiario_Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoDiarioAlimento",
                columns: table => new
                {
                    Alimento_Id = table.Column<int>(type: "int", nullable: false),
                    ConsumoDiario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDiarioAlimento", x => new { x.ConsumoDiario_Id, x.Alimento_Id });
                    table.ForeignKey(
                        name: "FK_ConsumoDiarioAlimento_Alimento_Alimento_Id",
                        column: x => x.Alimento_Id,
                        principalTable: "Alimento",
                        principalColumn: "Alimento_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumoDiarioAlimento_ConsumoDiario_ConsumoDiario_Id",
                        column: x => x.ConsumoDiario_Id,
                        principalTable: "ConsumoDiario",
                        principalColumn: "ConsumoDiario_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoDiarioAlimento_Alimento_Id",
                table: "ConsumoDiarioAlimento",
                column: "Alimento_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoDiarioAlimento");

            migrationBuilder.DropTable(
                name: "ConsumoDiario");

            migrationBuilder.RenameColumn(
                name: "Potasio",
                table: "Alimento",
                newName: "Potacio");
        }
    }
}
