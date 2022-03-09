using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Usermig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotesTables",
                columns: table => new
                {
                    NoteId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPinned = table.Column<bool>(nullable: false),
                    IsArrchived = table.Column<bool>(nullable: false),
                    Remainder = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    BackImg = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesTables", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_NotesTables_UserTables_Id",
                        column: x => x.Id,
                        principalTable: "UserTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CollabratesTables",
                columns: table => new
                {
                    CollabeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollabeEmail = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false),
                    NoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollabratesTables", x => x.CollabeId);
                    table.ForeignKey(
                        name: "FK_CollabratesTables_UserTables_Id",
                        column: x => x.Id,
                        principalTable: "UserTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CollabratesTables_NotesTables_NoteId",
                        column: x => x.NoteId,
                        principalTable: "NotesTables",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LabelTables",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false),
                    NoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelTables", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_LabelTables_UserTables_Id",
                        column: x => x.Id,
                        principalTable: "UserTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabelTables_NotesTables_NoteId",
                        column: x => x.NoteId,
                        principalTable: "NotesTables",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollabratesTables_Id",
                table: "CollabratesTables",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CollabratesTables_NoteId",
                table: "CollabratesTables",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTables_Id",
                table: "LabelTables",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTables_NoteId",
                table: "LabelTables",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotesTables_Id",
                table: "NotesTables",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollabratesTables");

            migrationBuilder.DropTable(
                name: "LabelTables");

            migrationBuilder.DropTable(
                name: "NotesTables");

            migrationBuilder.DropTable(
                name: "UserTables");
        }
    }
}
