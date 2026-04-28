using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAcademico.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CursoId",
                table: "Matricula",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Alunos_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Cursos_CursoId",
                table: "Matricula",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Alunos_AlunoId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Cursos_CursoId",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_CursoId",
                table: "Matricula");
        }
    }
}
