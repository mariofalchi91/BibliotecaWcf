using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class CorrezioniVarie1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Prestiti_PrestitoId",
                table: "Libri");

            migrationBuilder.DropForeignKey(
                name: "FK_Utenti_Prestiti_PrestitoId",
                table: "Utenti");

            migrationBuilder.DropIndex(
                name: "IX_Utenti_PrestitoId",
                table: "Utenti");

            migrationBuilder.DropIndex(
                name: "IX_Libri_PrestitoId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "PrestitoId",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "PrestitoId",
                table: "Libri");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataIscrizione",
                table: "Utenti",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReso",
                table: "Prestiti",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_UtenteId",
                table: "Prestiti",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestiti_Libri_LibroId",
                table: "Prestiti",
                column: "LibroId",
                principalTable: "Libri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestiti_Utenti_UtenteId",
                table: "Prestiti",
                column: "UtenteId",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestiti_Libri_LibroId",
                table: "Prestiti");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestiti_Utenti_UtenteId",
                table: "Prestiti");

            migrationBuilder.DropIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti");

            migrationBuilder.DropIndex(
                name: "IX_Prestiti_UtenteId",
                table: "Prestiti");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataIscrizione",
                table: "Utenti",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrestitoId",
                table: "Utenti",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReso",
                table: "Prestiti",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrestitoId",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_PrestitoId",
                table: "Utenti",
                column: "PrestitoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Utenti_Prestiti_PrestitoId",
                table: "Utenti",
                column: "PrestitoId",
                principalTable: "Prestiti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
