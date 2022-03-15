using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GISA.Convenio.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(200)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(18)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Convenios", x => x.Id));

            migrationBuilder.CreateTable(
                name: "EnderecoConvenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(200)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoConvenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoConvenio_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoConvenio_ConvenioId",
                table: "EnderecoConvenio",
                column: "ConvenioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoConvenio");

            migrationBuilder.DropTable(
                name: "Convenios");
        }
    }
}
