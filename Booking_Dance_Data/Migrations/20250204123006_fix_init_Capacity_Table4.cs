using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Dance_Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_init_Capacity_Table4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassDances_Accounts_AccountId1",
                table: "ClassDances");

            migrationBuilder.DropIndex(
                name: "IX_ClassDances_AccountId1",
                table: "ClassDances");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "ClassDances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "ClassDances",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassDances_AccountId1",
                table: "ClassDances",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDances_Accounts_AccountId1",
                table: "ClassDances",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
