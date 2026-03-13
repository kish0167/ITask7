using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_item_field_values",
                table: "item_field_values");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "item_field_values");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_field_values",
                table: "item_field_values",
                columns: new[] { "ItemId", "FieldId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_item_field_values",
                table: "item_field_values");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "item_field_values",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_item_field_values",
                table: "item_field_values",
                column: "Id");
        }
    }
}
