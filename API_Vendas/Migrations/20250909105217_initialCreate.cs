using System;
using Desafio_e_commerce_AVANADE_Vendas.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio_e_commerce_AVANADE_Vendas.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:tipo_usuario", "admin,comprador,vendedor");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Genero = table.Column<string>(type: "text", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Endereço = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<Tipo_Usuario>(type: "tipo_usuario", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registro_Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Comprador = table.Column<int>(type: "integer", nullable: false),
                    Id_Vendedor = table.Column<int>(type: "integer", nullable: false),
                    Id_Produto = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Valor_Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Endereço_Venda = table.Column<string>(type: "text", nullable: true),
                    Data_Venda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status_Venda = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_Venda_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_Venda_Usuario_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_Vendas_Comprador",
                        column: x => x.Id_Comprador,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registro_Vendas_Produtos",
                        column: x => x.Id_Produto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registro_Vendas_Vendedor",
                        column: x => x.Id_Vendedor,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Venda_Id_Comprador",
                table: "Registro_Venda",
                column: "Id_Comprador");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Venda_Id_Produto",
                table: "Registro_Venda",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Venda_Id_Vendedor",
                table: "Registro_Venda",
                column: "Id_Vendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Venda_UsuarioId",
                table: "Registro_Venda",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Venda_UsuarioId1",
                table: "Registro_Venda",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro_Venda");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
