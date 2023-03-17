using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDeRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoDiarioAlimento_Alimento_Alimento_Id",
                table: "ConsumoDiarioAlimento");

            migrationBuilder.CreateTable(
                name: "AlimentoCargado",
                columns: table => new
                {
                    AlimentoCargado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alimento_Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Calorias = table.Column<float>(type: "real", nullable: false),
                    Carbohidratos = table.Column<float>(type: "real", nullable: false),
                    Proteina = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    Sodio = table.Column<float>(type: "real", nullable: false),
                    Potasio = table.Column<float>(type: "real", nullable: false),
                    Fibra = table.Column<float>(type: "real", nullable: false),
                    Azucar = table.Column<float>(type: "real", nullable: false),
                    VitaminaA = table.Column<float>(type: "real", nullable: false),
                    VitaminaC = table.Column<float>(type: "real", nullable: false),
                    Calcio = table.Column<float>(type: "real", nullable: false),
                    Hierro = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoCargado", x => x.AlimentoCargado_Id);
                    table.ForeignKey(
                        name: "FK_AlimentoCargado_Alimento_Alimento_Id",
                        column: x => x.Alimento_Id,
                        principalTable: "Alimento",
                        principalColumn: "Alimento_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoCargado_Alimento_Id",
                table: "AlimentoCargado",
                column: "Alimento_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoDiarioAlimento_AlimentoCargado_Alimento_Id",
                table: "ConsumoDiarioAlimento",
                column: "Alimento_Id",
                principalTable: "AlimentoCargado",
                principalColumn: "AlimentoCargado_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoDiarioAlimento_AlimentoCargado_Alimento_Id",
                table: "ConsumoDiarioAlimento");

            migrationBuilder.DropTable(
                name: "AlimentoCargado");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoDiarioAlimento_Alimento_Alimento_Id",
                table: "ConsumoDiarioAlimento",
                column: "Alimento_Id",
                principalTable: "Alimento",
                principalColumn: "Alimento_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
