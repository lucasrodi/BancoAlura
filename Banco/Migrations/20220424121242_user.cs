using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioLogadoId = table.Column<int>(type: "int", nullable: false),
                    BancoOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgenciaOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BancoDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgenciaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataImportacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioLogado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transferencias");
        }
    }
}
