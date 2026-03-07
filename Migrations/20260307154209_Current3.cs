using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "inventories_accesses",
                keyColumns: new[] { "InventoryId", "UserId" },
                keyValues: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "99997999-7b3e-418f-9f53-38ec31c09abb" });

            migrationBuilder.DeleteData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("13076fc0-6401-43d3-a29c-94ffd5ff51bb"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("191c7193-bd4a-4ed9-b036-f6a2a28a705d"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("26507aec-617e-4610-b6f9-58d610f35908"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("28e63424-9be7-4f72-8790-9c6ee8cb0474"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("35a889c5-e79c-4ea5-8c1f-949613d6741d"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("3d157648-e8dc-4876-af1c-66b4b1190076"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("4095b801-a4fa-4bb3-b35f-35d48c9bd8d7"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("47c6698b-e50d-4ce0-9856-65fa558955fb"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("4d8af55a-30ca-49bc-9db0-9a5ac2403ef4"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6fd6cf9e-c13a-4f02-bf7c-a4a140d17897"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("708ef12a-cc32-48b3-9a52-1565c0552490"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("77f7fbcb-a7f5-406b-bb92-ac714c03fd21"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("8f37d808-9fb6-4d09-bb71-91ae757a1173"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("91d49827-64bf-41c0-9c2e-4628475f0375"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("95197323-f634-4664-a783-1d2e4dfea39c"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("a8128395-84b5-4768-bce9-15cbc35c0a9e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("b056a644-8666-4da0-ac34-42a0b98b2a32"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("bb2aff18-cef2-4e37-a25c-7040477ef5d4"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("c5071b87-9f64-4f86-bf7d-7c11dad0df39"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("d31ef362-7c76-4f23-9008-9b4b1be11b38"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("dfd72a15-429b-46e8-b290-17174938ecdd"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("e43661ad-b2a6-438f-978d-df21cef1f0a1"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("ed6c7a21-51ae-4b8e-bbdf-f21ed5ecc05d"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("f3663813-0590-43c9-a028-6e55fe848add"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("fd3af1c5-1fff-4702-aeab-08c10399f182"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("fe49164b-9768-4052-bb2a-a166d016e712"));

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

            migrationBuilder.DropColumn(
                name: "ValueDocumentUrl",
                table: "item_field_values");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ValueDocumentUrl",
                table: "item_field_values",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99997999-7b3e-418f-9f53-38ec31c09abb", 0, "68121b8c-c149-41e1-bedd-4c39f44cb6a4", "admin@company.com", true, false, null, "ADMIN@COMPANY.COM", "ADMIN@COMPANY.COM", null, null, false, "10edd645-3574-409e-bbaa-8c7c3806765d", false, "admin@company.com" });

            migrationBuilder.InsertData(
                table: "inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track laptops, monitors, peripherals, and other IT assets", "IT Equipment", new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.InsertData(
                table: "inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsPublic", "Name", "UpdatedAt" },
                values: new object[] { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 28, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track stationery, printer supplies, and office consumables", true, "Office Supplies", new DateTime(2026, 2, 28, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.InsertData(
                table: "inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 2, 23, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "Company vehicles and maintenance records", "Vehicle Fleet", new DateTime(2026, 2, 23, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.InsertData(
                table: "inventories_accesses",
                columns: new[] { "InventoryId", "UserId" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "99997999-7b3e-418f-9f53-38ec31c09abb" });

            migrationBuilder.InsertData(
                table: "inventory_fields",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayInTable", "FieldType", "InventoryId", "IsRequired", "Name", "SortOrder", "Title" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Physical asset tag number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "asset_tag", 1, "Asset Tag" },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Manufacturer serial number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "serial_number", 2, "Serial Number" },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Original purchase price in USD", true, "Numeric", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "purchase_price", 3, "Purchase Price" },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Warranty expiration date", false, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "warranty_expires", 4, "Warranty Expires" },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Currently assigned to employee", true, "Boolean", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "is_assigned", 5, "Assigned" },
                    { new Guid("a6666666-6666-6666-6666-666666666666"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Additional information", false, "MultiLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "notes", 6, "Notes" },
                    { new Guid("a7777777-7777-7777-7777-777777777777"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Upload purchase documentation", false, "Document", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "receipt", 7, "Purchase Receipt" },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Name of the supply item", true, "SingleLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "product_name", 1, "Product Name" },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Current stock count", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "quantity", 2, "Quantity in Stock" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Minimum stock before reorder", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "reorder_point", 3, "Reorder Point" },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Supplier contact and ordering details", false, "MultiLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), false, "supplier_info", 4, "Supplier Information" },
                    { new Guid("e1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Vehicle registration number", true, "SingleLine", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "license_plate", 1, "License Plate" },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Odometer reading", true, "Numeric", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "mileage", 2, "Current Mileage" },
                    { new Guid("e3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Current insurance status", true, "Boolean", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "insurance_active", 3, "Insurance Active" },
                    { new Guid("e4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "Annual inspection reports", false, "Document", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), false, "inspection_docs", 4, "Inspection Documents" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomId", "InventoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-001", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 15, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-002", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 5, 15, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-MON-001", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) },
                    { new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-A4-PAPER", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 1, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-TONER-BLK", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 3, 3, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) },
                    { new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 26, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), "99997999-7b3e-418f-9f53-38ec31c09abb", "VH-001", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 3, 5, 12, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) }
                });

            migrationBuilder.InsertData(
                table: "item_field_values",
                columns: new[] { "Id", "CreatedAt", "FieldId", "ItemId", "UpdatedAt", "ValueBoolean", "ValueDocumentUrl", "ValueNumeric", "ValueText" },
                values: new object[,]
                {
                    { new Guid("13076fc0-6401-43d3-a29c-94ffd5ff51bb"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "2027-06-20" },
                    { new Guid("191c7193-bd4a-4ed9-b036-f6a2a28a705d"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("e4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, "/docs/inspections/van-2024.pdf", null, null },
                    { new Guid("26507aec-617e-4610-b6f9-58d610f35908"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 1599.50m, null },
                    { new Guid("28e63424-9be7-4f72-8790-9c6ee8cb0474"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "SN123456789" },
                    { new Guid("35a889c5-e79c-4ea5-8c1f-949613d6741d"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("e3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), true, null, null, null },
                    { new Guid("3d157648-e8dc-4876-af1c-66b4b1190076"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "DELL-SN-778899" },
                    { new Guid("4095b801-a4fa-4bb3-b35f-35d48c9bd8d7"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "A4 Copy Paper (500 sheets)" },
                    { new Guid("47c6698b-e50d-4ce0-9856-65fa558955fb"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 3, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 3m, null },
                    { new Guid("4d8af55a-30ca-49bc-9db0-9a5ac2403ef4"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "ABC-1234" },
                    { new Guid("6fd6cf9e-c13a-4f02-bf7c-a4a140d17897"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "AST-2024-001" },
                    { new Guid("708ef12a-cc32-48b3-9a52-1565c0552490"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 349.00m, null },
                    { new Guid("77f7fbcb-a7f5-406b-bb92-ac714c03fd21"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "Staples Inc. - staples.com - Account #12345" },
                    { new Guid("8f37d808-9fb6-4d09-bb71-91ae757a1173"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), true, null, null, null },
                    { new Guid("91d49827-64bf-41c0-9c2e-4628475f0375"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "2027-03-15" },
                    { new Guid("95197323-f634-4664-a783-1d2e4dfea39c"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), true, null, null, null },
                    { new Guid("a8128395-84b5-4768-bce9-15cbc35c0a9e"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "SN987654321" },
                    { new Guid("b056a644-8666-4da0-ac34-42a0b98b2a32"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 2m, null },
                    { new Guid("bb2aff18-cef2-4e37-a25c-7040477ef5d4"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 10m, null },
                    { new Guid("c5071b87-9f64-4f86-bf7d-7c11dad0df39"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 12, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 45230m, null },
                    { new Guid("d31ef362-7c76-4f23-9008-9b4b1be11b38"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "AST-2024-002" },
                    { new Guid("dfd72a15-429b-46e8-b290-17174938ecdd"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 45m, null },
                    { new Guid("e43661ad-b2a6-438f-978d-df21cef1f0a1"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "HP LaserJet Black Toner 85A" },
                    { new Guid("ed6c7a21-51ae-4b8e-bbdf-f21ed5ecc05d"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), false, null, null, null },
                    { new Guid("f3663813-0590-43c9-a028-6e55fe848add"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a6666666-6666-6666-6666-666666666666"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "Assigned to Engineering team lead" },
                    { new Guid("fd3af1c5-1fff-4702-aeab-08c10399f182"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, null, "AST-2023-045" },
                    { new Guid("fe49164b-9768-4052-bb2a-a166d016e712"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), null, null, 1299.99m, null }
                });
        }
    }
}
