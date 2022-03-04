using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Labelmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_LabelTables_Id",
                table: "LabelTables",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTables_NoteId",
                table: "LabelTables",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelTables");
        }
    }
}
