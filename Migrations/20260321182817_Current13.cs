using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesForceId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesForceId",
                table: "AspNetUsers");
        }
    }
}
