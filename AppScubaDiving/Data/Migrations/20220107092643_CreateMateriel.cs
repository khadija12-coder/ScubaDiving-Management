using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppScubaDiving.Data.Migrations
{
    public partial class CreateMateriel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterielPlongee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMateriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterielPlongee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterielPlongee");
        }
    }
}
