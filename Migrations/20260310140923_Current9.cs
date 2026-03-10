using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_items_CustomId",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_items_InventoryId_CustomId",
                table: "items",
                columns: new[] { "InventoryId", "CustomId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_items_InventoryId_CustomId",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_items_CustomId",
                table: "items",
                column: "CustomId",
                unique: true);
        }
    }
}
