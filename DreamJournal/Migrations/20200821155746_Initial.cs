using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamJournal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dreams",
                columns: table => new
                {
                    DreamId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreams", x => x.DreamId);
                });

            migrationBuilder.InsertData(
                table: "Dreams",
                columns: new[] { "DreamId", "Body", "Title" },
                values: new object[] { 1, "I dreamt I was floating down a river in Thailand, that was forested, and had settlements on the side of the river.", "Polar Bear in Thailand" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dreams");
        }
    }
}
