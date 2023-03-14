using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumoAlimentario.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaAlimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Alimento_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Calorias = table.Column<float>(type: "real", nullable: false),
                    Carbohidratos = table.Column<float>(type: "real", nullable: false),
                    Proteina = table.Column<float>(type: "real", nullable: false),
                    GrasasTotales = table.Column<float>(type: "real", nullable: false),
                    Sodio = table.Column<float>(type: "real", nullable: false),
                    Potacio = table.Column<float>(type: "real", nullable: false),
                    Fibra = table.Column<float>(type: "real", nullable: false),
                    Azucar = table.Column<float>(type: "real", nullable: false),
                    VitaminaA = table.Column<float>(type: "real", nullable: false),
                    VitaminaC = table.Column<float>(type: "real", nullable: false),
                    Calcio = table.Column<float>(type: "real", nullable: false),
                    Hierro = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Alimento_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");
        }
    }
}
