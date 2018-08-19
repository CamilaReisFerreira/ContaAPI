using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Conta.DAL.Migrations
{
    public partial class conta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ID_Conta = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ID_Conta);
                });

            migrationBuilder.CreateTable(
                name: "Operacao",
                columns: table => new
                {
                    ID_Operacao = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaID_Conta = table.Column<long>(nullable: true),
                    Tipo_Operacao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao", x => x.ID_Operacao);
                    table.ForeignKey(
                        name: "FK_Operacao_Conta_ContaID_Conta",
                        column: x => x.ContaID_Conta,
                        principalTable: "Conta",
                        principalColumn: "ID_Conta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_ContaID_Conta",
                table: "Operacao",
                column: "ContaID_Conta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacao");

            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
