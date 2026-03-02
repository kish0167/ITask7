using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class NullableInventoryCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:field_type.field_type", "single_line,multi_line,numeric,document,boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "inventories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99997999-7b3e-418f-9f53-38ec31c09abb", 0, "898b0fb2-5ba5-40f2-988d-4128ad6fb60a", "admin@company.com", true, false, null, "ADMIN@COMPANY.COM", "ADMIN@COMPANY.COM", null, null, false, "b2b85423-7b4e-49f4-9975-ef235f365243", false, "admin@company.com" });

            migrationBuilder.InsertData(
                table: "inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track laptops, monitors, peripherals, and other IT assets", "IT Equipment", new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 25, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track stationery, printer supplies, and office consumables", "Office Supplies", new DateTime(2026, 2, 25, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 2, 20, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "Company vehicles and maintenance records", "Vehicle Fleet", new DateTime(2026, 2, 20, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) }
                });

            migrationBuilder.InsertData(
                table: "inventory_fields",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayInTable", "FieldType", "InventoryId", "IsRequired", "Name", "SortOrder", "Title" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Physical asset tag number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "asset_tag", 1, "Asset Tag" },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Manufacturer serial number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "serial_number", 2, "Serial Number" },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Original purchase price in USD", true, "Numeric", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "purchase_price", 3, "Purchase Price" },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Warranty expiration date", false, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "warranty_expires", 4, "Warranty Expires" },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Currently assigned to employee", true, "Boolean", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "is_assigned", 5, "Assigned" },
                    { new Guid("a6666666-6666-6666-6666-666666666666"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Additional information", false, "MultiLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "notes", 6, "Notes" },
                    { new Guid("a7777777-7777-7777-7777-777777777777"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Upload purchase documentation", false, "Document", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "receipt", 7, "Purchase Receipt" },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Name of the supply item", true, "SingleLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "product_name", 1, "Product Name" },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Current stock count", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "quantity", 2, "Quantity in Stock" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Minimum stock before reorder", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "reorder_point", 3, "Reorder Point" },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Supplier contact and ordering details", false, "MultiLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), false, "supplier_info", 4, "Supplier Information" },
                    { new Guid("e1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Vehicle registration number", true, "SingleLine", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "license_plate", 1, "License Plate" },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Odometer reading", true, "Numeric", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "mileage", 2, "Current Mileage" },
                    { new Guid("e3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Current insurance status", true, "Boolean", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "insurance_active", 3, "Insurance Active" },
                    { new Guid("e4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "Annual inspection reports", false, "Document", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), false, "inspection_docs", 4, "Inspection Documents" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomId", "DeletedAt", "InventoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-001", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 10, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-002", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 10, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 1, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-MON-001", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 1, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 27, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-A4-PAPER", null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 3, 1, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 26, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-TONER-BLK", null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 28, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 23, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), "99997999-7b3e-418f-9f53-38ec31c09abb", "VH-001", null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 3, 2, 7, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332) }
                });

            migrationBuilder.InsertData(
                table: "item_field_values",
                columns: new[] { "Id", "CreatedAt", "FieldId", "ItemId", "UpdatedAt", "ValueBoolean", "ValueDocumentUrl", "ValueNumeric", "ValueText" },
                values: new object[,]
                {
                    { new Guid("040b8f0e-6f4a-40f3-ad67-a4ca470ab7f1"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "AST-2023-045" },
                    { new Guid("04d3775c-ac6d-4993-ac39-4a1d561e412e"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 28, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 3m, null },
                    { new Guid("24a31199-1fee-4169-817e-769a02b3ad95"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a6666666-6666-6666-6666-666666666666"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "Assigned to Engineering team lead" },
                    { new Guid("2beb8618-6639-438e-b2e9-f338727a6cc8"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 1599.50m, null },
                    { new Guid("321b71f2-9350-4c67-a2c9-c9cbf1e78595"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "DELL-SN-778899" },
                    { new Guid("3b404075-a7d6-42de-99f1-0e0b3049c5a5"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 1299.99m, null },
                    { new Guid("3ca02a68-3be0-42be-b5c9-965ce61ad667"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "2027-06-20" },
                    { new Guid("3df43404-d116-4c83-a59f-fb0b9210e12e"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 7, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 45230m, null },
                    { new Guid("41bfaf5c-a4bd-4f87-a1b4-1c8fc1965aea"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("e4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, "/docs/inspections/van-2024.pdf", null, null },
                    { new Guid("4ff04b58-3d2b-4dd8-b361-3a48bf02dfe3"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), false, null, null, null },
                    { new Guid("67919566-fb0f-4af8-98d8-01a63967ef30"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), true, null, null, null },
                    { new Guid("6d38ddab-4e39-48cb-bfb8-d98ebef55216"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "SN987654321" },
                    { new Guid("6d507067-8c0f-4d29-aed1-f8fa14e00c14"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 10m, null },
                    { new Guid("7509da18-a6b1-4f2b-9ff5-d9c64b95bbbd"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "AST-2024-002" },
                    { new Guid("794a94a5-fb97-40c8-b474-5177f2873e4a"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 1, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 45m, null },
                    { new Guid("7cfca272-f8dc-4158-8326-dd40491c1d42"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "SN123456789" },
                    { new Guid("7d385fdd-5dff-4c16-b296-ee44732858b2"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 349.00m, null },
                    { new Guid("8ae8cf58-42ec-43a9-ad46-aa4eb1019e3a"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "A4 Copy Paper (500 sheets)" },
                    { new Guid("a1c64120-f527-464a-80d6-06330aaf9c37"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "2027-03-15" },
                    { new Guid("c7e538eb-fa83-47a5-8531-cbc87bb1b40c"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "Staples Inc. - staples.com - Account #12345" },
                    { new Guid("c800e8ea-237a-4710-a696-90b3b2648aed"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "HP LaserJet Black Toner 85A" },
                    { new Guid("ca4ee84a-db1c-4dd9-9e5b-66fff6b9bbe8"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), true, null, null, null },
                    { new Guid("cc6ffb49-9ca7-4f6e-9c9c-66df1e501211"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("e3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), true, null, null, null },
                    { new Guid("d90b3e6d-8a0f-401d-a76c-f23e43653b1c"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, 2m, null },
                    { new Guid("e7355608-f784-4dac-9efe-ae615a887fdb"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "ABC-1234" },
                    { new Guid("fab72190-d46b-4cd5-a443-c9cbd68708ed"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 12, 53, 5, 96, DateTimeKind.Utc).AddTicks(4332), null, null, null, "AST-2024-001" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories");

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("040b8f0e-6f4a-40f3-ad67-a4ca470ab7f1"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("04d3775c-ac6d-4993-ac39-4a1d561e412e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("24a31199-1fee-4169-817e-769a02b3ad95"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("2beb8618-6639-438e-b2e9-f338727a6cc8"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("321b71f2-9350-4c67-a2c9-c9cbf1e78595"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("3b404075-a7d6-42de-99f1-0e0b3049c5a5"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("3ca02a68-3be0-42be-b5c9-965ce61ad667"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("3df43404-d116-4c83-a59f-fb0b9210e12e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("41bfaf5c-a4bd-4f87-a1b4-1c8fc1965aea"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("4ff04b58-3d2b-4dd8-b361-3a48bf02dfe3"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("67919566-fb0f-4af8-98d8-01a63967ef30"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6d38ddab-4e39-48cb-bfb8-d98ebef55216"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6d507067-8c0f-4d29-aed1-f8fa14e00c14"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("7509da18-a6b1-4f2b-9ff5-d9c64b95bbbd"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("794a94a5-fb97-40c8-b474-5177f2873e4a"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("7cfca272-f8dc-4158-8326-dd40491c1d42"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("7d385fdd-5dff-4c16-b296-ee44732858b2"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("8ae8cf58-42ec-43a9-ad46-aa4eb1019e3a"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("a1c64120-f527-464a-80d6-06330aaf9c37"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("c7e538eb-fa83-47a5-8531-cbc87bb1b40c"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("c800e8ea-237a-4710-a696-90b3b2648aed"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("ca4ee84a-db1c-4dd9-9e5b-66fff6b9bbe8"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("cc6ffb49-9ca7-4f6e-9c9c-66df1e501211"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("d90b3e6d-8a0f-401d-a76c-f23e43653b1c"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("e7355608-f784-4dac-9efe-ae615a887fdb"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("fab72190-d46b-4cd5-a443-c9cbd68708ed"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99997999-7b3e-418f-9f53-38ec31c09abb");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:field_type.field_type", "single_line,multi_line,numeric,document,boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "inventories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inventories_AspNetUsers_CreatedBy",
                table: "inventories",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
