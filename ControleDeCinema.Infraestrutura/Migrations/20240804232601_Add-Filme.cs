using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Duracao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFilme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBSessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sala_Id = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime", nullable: false),
                    Filme_Id = table.Column<int>(type: "int", nullable: false),
                    QtdIngressos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBSessao_TBFilme",
                        column: x => x.Filme_Id,
                        principalTable: "TBFilme",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBSessao_TBSala",
                        column: x => x.Sala_Id,
                        principalTable: "TBSala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBIngresso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Assento = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sessao_Id = table.Column<int>(type: "int", nullable: false),
                    Funcionario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBIngresso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBIngresso_TBFuncionario",
                        column: x => x.Funcionario_Id,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBIngresso_TBSessao",
                        column: x => x.Sessao_Id,
                        principalTable: "TBSessao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBIngresso_Funcionario_Id",
                table: "TBIngresso",
                column: "Funcionario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBIngresso_Sessao_Id",
                table: "TBIngresso",
                column: "Sessao_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBSessao_Filme_Id",
                table: "TBSessao",
                column: "Filme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBSessao_Sala_Id",
                table: "TBSessao",
                column: "Sala_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBIngresso");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBSessao");

            migrationBuilder.DropTable(
                name: "TBFilme");

            migrationBuilder.DropTable(
                name: "TBSala");
        }
    }
}
