using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BibliotecaApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserLastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserDateYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserNumberOfDocument = table.Column<string>(type: "text", nullable: false),
                    UserRol = table.Column<string>(type: "text", nullable: false),
                    UserLibrosRetirados = table.Column<int>(type: "integer", nullable: false),
                    UserActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserPin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
