using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agua_e_Aventura.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Praias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    UrlFotosId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Praias_Regioes_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regioes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComentariosPraias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomedeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComentarioUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PraiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosPraias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosPraias_Praias_PraiaId",
                        column: x => x.PraiaId,
                        principalTable: "Praias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PraiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Praias_PraiaId",
                        column: x => x.PraiaId,
                        principalTable: "Praias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespostasComentariosPraias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomedeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespostasUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComentarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasComentariosPraias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasComentariosPraias_ComentariosPraias_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "ComentariosPraias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regioes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("4249ae61-c978-4c30-a8d6-5a6dec597325"), "Iranduba" },
                    { new Guid("77ffa92c-a132-4e17-ab20-864e8fc76737"), "Manaus" },
                    { new Guid("8e462a08-2a90-4261-b007-e3652ea74764"), "Presidente Figuereido" },
                    { new Guid("99581561-7fe3-4325-b5dc-c58f2d9b8a27"), "Manacapuru" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosPraias_PraiaId",
                table: "ComentariosPraias",
                column: "PraiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_PraiaId",
                table: "Fotos",
                column: "PraiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Praias_RegiaoId",
                table: "Praias",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasComentariosPraias_ComentarioId",
                table: "RespostasComentariosPraias",
                column: "ComentarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "RespostasComentariosPraias");

            migrationBuilder.DropTable(
                name: "ComentariosPraias");

            migrationBuilder.DropTable(
                name: "Praias");

            migrationBuilder.DropTable(
                name: "Regioes");
        }
    }
}
