using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Automobile.Infra.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cancelado = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    TipoDocumento = table.Column<short>(type: "SMALLINT", nullable: true),
                    Cancelado = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProprietarioEnderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietarioEnderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProprietarioEnderecos_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Renavam = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    AnoFabricacao = table.Column<string>(type: "varchar(50)", nullable: false),
                    AnoModelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_VeiculoId",
                table: "Modelos",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProprietarioEnderecos_ProprietarioId",
                table: "ProprietarioEnderecos",
                column: "ProprietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MarcaId",
                table: "Veiculos",
                column: "MarcaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "ProprietarioEnderecos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Proprietarios");
        }
    }
}
