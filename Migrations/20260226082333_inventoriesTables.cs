using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class inventoriesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:field_type.field_type", "single_line,multi_line,numeric,document,boolean");

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventory_fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FieldType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayInTable = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_fields_inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_field_values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueText = table.Column<string>(type: "text", nullable: false),
                    ValueNumeric = table.Column<decimal>(type: "numeric", nullable: true),
                    ValueBoolean = table.Column<bool>(type: "boolean", nullable: true),
                    ValueDocumentUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_field_values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_item_field_values_inventory_fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "inventory_fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_field_values_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_fields_InventoryId_Name",
                table: "inventory_fields",
                columns: new[] { "InventoryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_fields_InventoryId_SortOrder",
                table: "inventory_fields",
                columns: new[] { "InventoryId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_item_field_values_FieldId",
                table: "item_field_values",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_item_field_values_ItemId_FieldId",
                table: "item_field_values",
                columns: new[] { "ItemId", "FieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_CustomId",
                table: "items",
                column: "CustomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_InventoryId",
                table: "items",
                column: "InventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_field_values");

            migrationBuilder.DropTable(
                name: "inventory_fields");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:field_type.field_type", "single_line,multi_line,numeric,document,boolean");
        }
    }
}
