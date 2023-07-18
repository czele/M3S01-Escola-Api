using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class escolaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    GENERO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TELEFONE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO_ID", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "MATERIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATERIA_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURSO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValue: "Curso Basico"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOLETIM_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOLETIM_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "ALUNO",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTAS_MATERIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoletimId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTASMATERIA_ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIA_BOLETIM_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "BOLETIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "MATERIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_EMAIL",
                table: "ALUNO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_AlunoId",
                table: "BOLETIM",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAS_MATERIA_MateriaId",
                table: "NOTAS_MATERIA",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TURMA_NOME",
                table: "TURMA",
                column: "NOME",
                unique: true,
                filter: "[NOME] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTAS_MATERIA");

            migrationBuilder.DropTable(
                name: "TURMA");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "MATERIA");

            migrationBuilder.DropTable(
                name: "ALUNO");
        }
    }
}
