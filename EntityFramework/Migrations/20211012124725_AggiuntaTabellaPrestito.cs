using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class AggiuntaTabellaPrestito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titolo",
                table: "Libri",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Sommario",
                table: "Libri",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Libri",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Autore",
                table: "Libri",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PrestitoId",
                table: "Libri",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prestiti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utente = table.Column<string>(maxLength: 100, nullable: false),
                    DataPrestito = table.Column<DateTime>(nullable: false),
                    DataReso = table.Column<DateTime>(nullable: true),
                    LibroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestiti", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_PrestitoId",
                table: "Libri",
                column: "PrestitoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Prestiti_PrestitoId",
                table: "Libri",
                column: "PrestitoId",
                principalTable: "Prestiti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Prestiti_PrestitoId",
                table: "Libri");

            migrationBuilder.DropTable(
                name: "Prestiti");

            migrationBuilder.DropIndex(
                name: "IX_Libri_PrestitoId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "PrestitoId",
                table: "Libri");

            migrationBuilder.AlterColumn<string>(
                name: "Titolo",
                table: "Libri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Sommario",
                table: "Libri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "Libri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Autore",
                table: "Libri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
