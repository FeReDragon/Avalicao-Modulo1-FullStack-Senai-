using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nota = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    QuantidadeAtendimentosPedagogicos = table.Column<int>(type: "int", nullable: false),
                    SituacaoMatricula = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedagogos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantidadeAtendimentosPedagogicosRealizados = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogos", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormacaoAcademica = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExperienciaDesenvolvimento = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AtendimentoPedagogico",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoAluno = table.Column<int>(type: "int", nullable: false),
                    CodigoPedagogo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoPedagogico", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_AtendimentoPedagogico_Alunos_CodigoAluno",
                        column: x => x.CodigoAluno,
                        principalTable: "Alunos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoPedagogico_Pedagogos_CodigoPedagogo",
                        column: x => x.CodigoPedagogo,
                        principalTable: "Pedagogos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Codigo", "CPF", "DataNascimento", "Nome", "Nota", "QuantidadeAtendimentosPedagogicos", "SituacaoMatricula", "Telefone" },
                values: new object[,]
                {
                    { 1, "11839750012", new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", 3.5m, 0, "Inativo", "11-11111-1" },
                    { 2, "17158947092", new DateTime(2012, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", 100m, 0, "Ativo", "11-22222-2" },
                    { 3, "63701210082", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meggie", 90m, 0, "Ativo", "12-20002-2" },
                    { 4, "30119137052", new DateTime(2014, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milhouse", 80m, 0, "Ativo", "11-33333-2" },
                    { 5, "95704094011", new DateTime(2007, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nelson", 20m, 0, "Inativo", "11-44333-4" }
                });

            migrationBuilder.InsertData(
                table: "Pedagogos",
                columns: new[] { "Codigo", "CPF", "DataNascimento", "Nome", "QuantidadeAtendimentosPedagogicosRealizados", "Telefone" },
                values: new object[,]
                {
                    { 1, "86940162033", new DateTime(1980, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saul", 20, "44-11998-1" },
                    { 2, "62316840021", new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 30, "11-67333-4" },
                    { 3, "49850253056", new DateTime(2004, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sansa", 15, "22-22333-4" },
                    { 4, "39125106047", new DateTime(1990, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyrion", 25, "33-77333-4" },
                    { 5, "13289759018", new DateTime(1995, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandor", 10, "11-33333-2" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Codigo", "CPF", "DataNascimento", "Estado", "ExperienciaDesenvolvimento", "FormacaoAcademica", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "40539019088", new DateTime(1982, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20, "Mestre em Química", "Walter", "14-22998-1" },
                    { 2, "96107295034", new DateTime(1997, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, "Bacharel em Física", "Jesse", "44-11111-1" },
                    { 3, "70685977051", new DateTime(1984, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 15, "Doutor em Geologia", "Hank", "44-11111-1" },
                    { 4, "57408927099", new DateTime(1977, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 25, "MBA em Administração", "Gustavo", "44-11001-1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPedagogico_CodigoAluno",
                table: "AtendimentoPedagogico",
                column: "CodigoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPedagogico_CodigoPedagogo",
                table: "AtendimentoPedagogico",
                column: "CodigoPedagogo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoPedagogico");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Pedagogos");
        }
    }
}
