using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTables_UserTables_Id1",
                table: "NotesTables");

            migrationBuilder.DropIndex(
                name: "IX_NotesTables_Id1",
                table: "NotesTables");

            migrationBuilder.DropColumn(
                name: "Id1",
                table: "NotesTables");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "NotesTables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NotesTables_Id",
                table: "NotesTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTables_UserTables_Id",
                table: "NotesTables",
                column: "Id",
                principalTable: "UserTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTables_UserTables_Id",
                table: "NotesTables");

            migrationBuilder.DropIndex(
                name: "IX_NotesTables_Id",
                table: "NotesTables");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NotesTables");

            migrationBuilder.AddColumn<long>(
                name: "Id1",
                table: "NotesTables",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotesTables_Id1",
                table: "NotesTables",
                column: "Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTables_UserTables_Id1",
                table: "NotesTables",
                column: "Id1",
                principalTable: "UserTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
