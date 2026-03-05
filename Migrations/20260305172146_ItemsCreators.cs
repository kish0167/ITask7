using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class ItemsCreators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "items");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99997999-7b3e-418f-9f53-38ec31c09abb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68121b8c-c149-41e1-bedd-4c39f44cb6a4", "10edd645-3574-409e-bbaa-8c7c3806765d" });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 28, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 2, 28, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 2, 23, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "inventory_fields",
                keyColumn: "Id",
                keyValue: new Guid("e4444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789));

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

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 5, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 5, 15, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 5, 15, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 4, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 3, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 17, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 3, 5, 12, 21, 45, 353, DateTimeKind.Utc).AddTicks(3789) });

            migrationBuilder.CreateIndex(
                name: "IX_items_CreatedBy",
                table: "items",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email")
                .Annotation("Npgsql:IndexMethod", "BTree")
                .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });

            migrationBuilder.AddForeignKey(
                name: "FK_items_AspNetUsers_CreatedBy",
                table: "items",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_AspNetUsers_CreatedBy",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_CreatedBy",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "items",
                type: "timestamp with time zone",
                nullable: true);

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 25, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 2, 25, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "inventories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 20, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 2, 20, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

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
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 3, 2, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 2, 17, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 3, 2, 17, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 27, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 3, 1, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 26, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 2, 28, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 23, 19, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086), null, new DateTime(2026, 3, 2, 14, 52, 13, 133, DateTimeKind.Utc).AddTicks(4086) });
        }
    }
}
