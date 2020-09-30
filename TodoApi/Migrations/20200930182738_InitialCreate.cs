using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Usuario = table.Column<string>(maxLength: 20, nullable: false),
                    Senha = table.Column<string>(maxLength: 20, nullable: false),
                    NivelTime = table.Column<int>(nullable: false),
                    IdTime = table.Column<long>(nullable: false),
                    TimeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Times_IdTime",
                        column: x => x.IdTime,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    IdPessoa = table.Column<long>(nullable: false),
                    IdTime = table.Column<long>(nullable: false),
                    TimesId = table.Column<long>(nullable: true),
                    PessoaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoItems_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoItems_Times_TimesId",
                        column: x => x.TimesId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_IdTime",
                table: "Pessoas",
                column: "IdTime");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TimeId",
                table: "Pessoas",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_IdPessoa",
                table: "TodoItems",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_PessoaId",
                table: "TodoItems",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TimesId",
                table: "TodoItems",
                column: "TimesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
