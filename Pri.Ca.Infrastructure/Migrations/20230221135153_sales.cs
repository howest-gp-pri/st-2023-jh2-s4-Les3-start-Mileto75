using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Ca.Infrastructure.Migrations
{
    public partial class sales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "GameId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 2, null, 10 },
                    { 3, 3, null, 2 },
                    { 4, 1, null, 8 },
                    { 5, 2, null, 12 },
                    { 6, 3, null, 4 },
                    { 7, 1, null, 10 },
                    { 8, 2, null, 1 },
                    { 9, 3, null, 5 },
                    { 10, 1, null, 13 },
                    { 12, 2, null, 1 },
                    { 13, 3, null, 4 },
                    { 14, 1, null, 8 },
                    { 15, 2, null, 4 },
                    { 16, 3, null, 23 },
                    { 17, 1, null, 2 },
                    { 18, 2, null, 7 },
                    { 19, 3, null, 9 },
                    { 20, 1, null, 10 },
                    { 21, 2, null, 2 },
                    { 22, 3, null, 5 },
                    { 23, 1, null, 9 },
                    { 24, 2, null, 8 },
                    { 25, 3, null, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GameId",
                table: "Sales",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
