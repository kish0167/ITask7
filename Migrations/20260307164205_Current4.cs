using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "inventories",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_inventories_CreatedBy",
                table: "inventories",
                newName: "IX_inventories_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventories_AspNetUsers_CreatorId",
                table: "inventories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_AspNetUsers_CreatorId",
                table: "inventories");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "inventories",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_inventories_CreatorId",
                table: "inventories",
                newName: "IX_inventories_CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
