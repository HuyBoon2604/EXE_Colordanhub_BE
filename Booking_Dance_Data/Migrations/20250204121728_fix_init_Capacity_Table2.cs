using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Dance_Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_init_Capacity_Table2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_Categories_CategoryId1",
                table: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Studios_CategoryId1",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Studios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "Studios",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studios_CategoryId1",
                table: "Studios",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_Categories_CategoryId1",
                table: "Studios",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
