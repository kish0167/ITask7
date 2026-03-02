using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("03e1af4a-e747-49c5-bd41-21921fcae76e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("187f4b82-8adb-4079-b9dc-a5e9fcabe3cd"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("18d61117-07b7-46a8-bd61-a2433533550e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("1c4b97bf-7a13-495a-bcd7-6cdd1b6bfd68"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("1dce9092-e108-4720-ba51-fd30250317f0"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("1efe8d79-cec2-4fff-8498-28a525cfaf96"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("24845f7d-2a50-4ae7-be6d-66627aec2c5b"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("2885c2cb-001d-4c9c-9a3b-d5bde6cc56d2"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("428d9378-cfa7-435a-a9ed-34ee2563c9f5"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("46a496e2-852b-4571-b15c-a8c072694c19"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("48e60de2-698a-44ff-8793-4c58279aad48"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("4f7c7238-de58-41a9-b0ac-4af1bfbaac4c"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("5bfb3345-4e3f-474c-a35e-ebe71db68346"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("5e829980-3c57-44a1-8fb8-c245bf7e5bb5"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("5f42a60d-5a01-4a0d-b604-d3d0a9394af6"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("615a386b-9b31-4d6c-b7ec-13f583d3dab6"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("620468dd-a6fe-4351-bf85-41fe052581b8"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("622b849f-a9ab-4871-8c03-bd424db09f4a"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("643ad983-6f65-4247-bf32-6a661546bfb4"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("66ad5337-a3e0-4d79-a924-0bebde202ad9"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6c789b79-9a16-4f26-946e-1e3608ec91b6"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("831ed8b4-2f3c-427e-94df-df058e44443d"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("87e88b53-0ce7-45a0-a46a-c2690c10b46d"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("c483168c-b50e-4b1c-a616-fd4f86d62474"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("e622eb36-d6ba-4a7c-9a2d-0aa34d059720"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("fbfc2126-6b16-4880-a925-179deffc7589"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99997999-7b3e-418f-9f53-38ec31c09abb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f6c6266-6c5b-4b93-82d0-faee1d039008", "0118ffa2-c199-4f5f-bda5-d2fd4ae7cf15" });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "IsPublic", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), true, new DateTime(2026, 2, 25, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 20, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 2, 20, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.InsertData(
                table: "inventories_accesses",
                columns: new[] { "InventoryId", "UserId" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "99997999-7b3e-418f-9f53-38ec31c09abb" });

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.InsertData(
                table: "item_field_values",
                columns: new[] { "Id", "CreatedAt", "FieldId", "ItemId", "UpdatedAt", "ValueBoolean", "ValueDocumentUrl", "ValueNumeric", "ValueText" },
                values: new object[,]
                {
                    { new Guid("0743ff03-788e-45a5-a5ed-363ea73dba07"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), true, null, null, null },
                    { new Guid("1a0e5a95-968f-440d-9a19-b146421961ba"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a6666666-6666-6666-6666-666666666666"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "Assigned to Engineering team lead" },
                    { new Guid("2688b07b-680c-4a3d-b917-3fd3fad0b399"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "AST-2023-045" },
                    { new Guid("2fc24ade-281e-4f82-a47b-24970fa0c39a"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "HP LaserJet Black Toner 85A" },
                    { new Guid("323cccba-ef93-45be-9f5b-5174a76367b2"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("e4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, "/docs/inspections/van-2024.pdf", null, null },
                    { new Guid("3b61703d-85b9-417e-8a67-5ab521f58e9e"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "ABC-1234" },
                    { new Guid("42d24187-094d-437e-b6fd-a249df0fd295"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 349.00m, null },
                    { new Guid("4702bc73-76a2-4c2e-9c69-262a2d19fcc2"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("e3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), true, null, null, null },
                    { new Guid("5387e01e-dbbc-48ac-8c86-8e2e391a19d4"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "Staples Inc. - staples.com - Account #12345" },
                    { new Guid("575f61d8-11c1-49bd-a272-dcbc91cb1a32"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "2027-06-20" },
                    { new Guid("6a111047-ad38-4ee6-8fcf-c25131451375"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "2027-03-15" },
                    { new Guid("6a734c82-5ff3-4628-bede-a6b8192c8743"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 2m, null },
                    { new Guid("6e0b18fd-bdc0-494e-ba85-2b3f24e4e534"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 45m, null },
                    { new Guid("75732db6-171a-456f-b749-1060d38beac5"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 28, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 3m, null },
                    { new Guid("8dedd63f-fb5a-4363-afd5-064a0f7d7c79"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "AST-2024-002" },
                    { new Guid("90d8054e-0f8e-45fd-9505-25242c25d018"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 1299.99m, null },
                    { new Guid("9692739f-0938-44d4-b377-5840f8ee3239"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 10m, null },
                    { new Guid("98ec1452-5ea0-4ba7-b03d-c21f07398f40"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), false, null, null, null },
                    { new Guid("b81eabd6-6c89-4f9f-a93f-1dfbcfc8ec9e"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "SN123456789" },
                    { new Guid("b8ea6a26-b6e4-4e41-bd40-0c0775f310a2"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 14, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 45230m, null },
                    { new Guid("d2dfac9b-e574-4048-b2ef-ce524fe17cfd"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), true, null, null, null },
                    { new Guid("d89c332e-e48b-43b5-888c-438e7d77e00f"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "A4 Copy Paper (500 sheets)" },
                    { new Guid("e232550f-983e-488a-be32-79ec8d4a640a"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "SN987654321" },
                    { new Guid("ec8017a0-9ee0-46e8-9a4b-434a971a0aab"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "DELL-SN-778899" },
                    { new Guid("f58ceadc-9686-4fdc-b412-ed2db4d4e2e3"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, null, "AST-2024-001" },
                    { new Guid("ff362eed-aaa3-45cb-9403-da426c93d077"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, null, 1599.50m, null }
                });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 17, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 2, 17, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 27, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 2, 28, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 3, 2, 14, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "inventories_accesses",
                keyColumns: new[] { "InventoryId", "UserId" },
                keyValues: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "99997999-7b3e-418f-9f53-38ec31c09abb" });

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("0743ff03-788e-45a5-a5ed-363ea73dba07"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("1a0e5a95-968f-440d-9a19-b146421961ba"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("2688b07b-680c-4a3d-b917-3fd3fad0b399"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("2fc24ade-281e-4f82-a47b-24970fa0c39a"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("323cccba-ef93-45be-9f5b-5174a76367b2"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("3b61703d-85b9-417e-8a67-5ab521f58e9e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("42d24187-094d-437e-b6fd-a249df0fd295"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("4702bc73-76a2-4c2e-9c69-262a2d19fcc2"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("5387e01e-dbbc-48ac-8c86-8e2e391a19d4"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("575f61d8-11c1-49bd-a272-dcbc91cb1a32"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6a111047-ad38-4ee6-8fcf-c25131451375"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6a734c82-5ff3-4628-bede-a6b8192c8743"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("6e0b18fd-bdc0-494e-ba85-2b3f24e4e534"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("75732db6-171a-456f-b749-1060d38beac5"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("8dedd63f-fb5a-4363-afd5-064a0f7d7c79"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("90d8054e-0f8e-45fd-9505-25242c25d018"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("9692739f-0938-44d4-b377-5840f8ee3239"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("98ec1452-5ea0-4ba7-b03d-c21f07398f40"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("b81eabd6-6c89-4f9f-a93f-1dfbcfc8ec9e"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("b8ea6a26-b6e4-4e41-bd40-0c0775f310a2"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("d2dfac9b-e574-4048-b2ef-ce524fe17cfd"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("d89c332e-e48b-43b5-888c-438e7d77e00f"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("e232550f-983e-488a-be32-79ec8d4a640a"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("ec8017a0-9ee0-46e8-9a4b-434a971a0aab"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("f58ceadc-9686-4fdc-b412-ed2db4d4e2e3"));

            migrationBuilder.DeleteData(
                table: "item_field_values",
                keyColumn: "Id",
                keyValue: new Guid("ff362eed-aaa3-45cb-9403-da426c93d077"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99997999-7b3e-418f-9f53-38ec31c09abb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4468f516-58c0-4a25-af81-a811fa7559e9", "3c2e3517-2d99-495c-a2ce-2e8740351765" });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "IsPublic", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), false, new DateTime(2026, 2, 25, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 20, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 2, 20, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.InsertData(
                table: "item_field_values",
                columns: new[] { "Id", "CreatedAt", "FieldId", "ItemId", "UpdatedAt", "ValueBoolean", "ValueDocumentUrl", "ValueNumeric", "ValueText" },
                values: new object[,]
                {
                    { new Guid("03e1af4a-e747-49c5-bd41-21921fcae76e"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "SN123456789" },
                    { new Guid("187f4b82-8adb-4079-b9dc-a5e9fcabe3cd"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "AST-2023-045" },
                    { new Guid("18d61117-07b7-46a8-bd61-a2433533550e"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "AST-2024-001" },
                    { new Guid("1c4b97bf-7a13-495a-bcd7-6cdd1b6bfd68"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("e2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 14, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 45230m, null },
                    { new Guid("1dce9092-e108-4720-ba51-fd30250317f0"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "SN987654321" },
                    { new Guid("1efe8d79-cec2-4fff-8498-28a525cfaf96"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), false, null, null, null },
                    { new Guid("24845f7d-2a50-4ae7-be6d-66627aec2c5b"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 1299.99m, null },
                    { new Guid("2885c2cb-001d-4c9c-9a3b-d5bde6cc56d2"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 2m, null },
                    { new Guid("428d9378-cfa7-435a-a9ed-34ee2563c9f5"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "AST-2024-002" },
                    { new Guid("46a496e2-852b-4571-b15c-a8c072694c19"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "Staples Inc. - staples.com - Account #12345" },
                    { new Guid("48e60de2-698a-44ff-8793-4c58279aad48"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), true, null, null, null },
                    { new Guid("4f7c7238-de58-41a9-b0ac-4af1bfbaac4c"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("e1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "ABC-1234" },
                    { new Guid("5bfb3345-4e3f-474c-a35e-ebe71db68346"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("e3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), true, null, null, null },
                    { new Guid("5e829980-3c57-44a1-8fb8-c245bf7e5bb5"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "DELL-SN-778899" },
                    { new Guid("5f42a60d-5a01-4a0d-b604-d3d0a9394af6"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a6666666-6666-6666-6666-666666666666"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "Assigned to Engineering team lead" },
                    { new Guid("615a386b-9b31-4d6c-b7ec-13f583d3dab6"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a5555555-5555-5555-5555-555555555555"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), true, null, null, null },
                    { new Guid("620468dd-a6fe-4351-bf85-41fe052581b8"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 10m, null },
                    { new Guid("622b849f-a9ab-4871-8c03-bd424db09f4a"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "2027-06-20" },
                    { new Guid("643ad983-6f65-4247-bf32-6a661546bfb4"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("e4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, "/docs/inspections/van-2024.pdf", null, null },
                    { new Guid("66ad5337-a3e0-4d79-a924-0bebde202ad9"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 349.00m, null },
                    { new Guid("6c789b79-9a16-4f26-946e-1e3608ec91b6"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "HP LaserJet Black Toner 85A" },
                    { new Guid("831ed8b4-2f3c-427e-94df-df058e44443d"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 1599.50m, null },
                    { new Guid("87e88b53-0ce7-45a0-a46a-c2690c10b46d"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("a4444444-4444-4444-4444-444444444444"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "2027-03-15" },
                    { new Guid("c483168c-b50e-4b1c-a616-fd4f86d62474"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, null, "A4 Copy Paper (500 sheets)" },
                    { new Guid("e622eb36-d6ba-4a7c-9a2d-0aa34d059720"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 28, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 3m, null },
                    { new Guid("fbfc2126-6b16-4880-a925-179deffc7589"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), null, null, 45m, null }
                });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 17, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 2, 17, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 27, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 2, 28, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 3, 2, 14, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) });
        }
    }
}
