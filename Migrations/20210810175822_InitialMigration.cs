using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BibliotecaApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LibroTitulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LibroAutores = table.Column<string>(type: "text", nullable: false),
                    LibroStock = table.Column<int>(type: "integer", nullable: false),
                    LibroPortada = table.Column<string>(type: "text", nullable: true),
                    LibroDescripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LiroCodigoIsbn = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
