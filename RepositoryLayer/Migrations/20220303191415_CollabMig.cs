using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CollabMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CollabratesTables_Id",
                table: "CollabratesTables",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CollabratesTables_NoteId",
                table: "CollabratesTables",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollabratesTables");
        }
    }
}
