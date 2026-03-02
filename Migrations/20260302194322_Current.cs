using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITask7.Migrations
{
    /// <inheritdoc />
    public partial class Current : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventories_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "inventories_accesses",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories_accesses", x => new { x.UserId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_inventories_accesses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventories_accesses_inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
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
                    ValueText = table.Column<string>(type: "text", nullable: true),
                    ValueNumeric = table.Column<decimal>(type: "numeric", nullable: true),
                    ValueBoolean = table.Column<bool>(type: "boolean", nullable: true),
                    ValueDocumentUrl = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99997999-7b3e-418f-9f53-38ec31c09abb", 0, "4468f516-58c0-4a25-af81-a811fa7559e9", "admin@company.com", true, false, null, "ADMIN@COMPANY.COM", "ADMIN@COMPANY.COM", null, null, false, "3c2e3517-2d99-495c-a2ce-2e8740351765", false, "admin@company.com" });

            migrationBuilder.InsertData(
                table: "inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track laptops, monitors, peripherals, and other IT assets", "IT Equipment", new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 25, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "Track stationery, printer supplies, and office consumables", "Office Supplies", new DateTime(2026, 2, 25, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 2, 20, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "Company vehicles and maintenance records", "Vehicle Fleet", new DateTime(2026, 2, 20, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) }
                });

            migrationBuilder.InsertData(
                table: "inventory_fields",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayInTable", "FieldType", "InventoryId", "IsRequired", "Name", "SortOrder", "Title" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Physical asset tag number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "asset_tag", 1, "Asset Tag" },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Manufacturer serial number", true, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "serial_number", 2, "Serial Number" },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Original purchase price in USD", true, "Numeric", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "purchase_price", 3, "Purchase Price" },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Warranty expiration date", false, "SingleLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "warranty_expires", 4, "Warranty Expires" },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Currently assigned to employee", true, "Boolean", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, "is_assigned", 5, "Assigned" },
                    { new Guid("a6666666-6666-6666-6666-666666666666"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Additional information", false, "MultiLine", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "notes", 6, "Notes" },
                    { new Guid("a7777777-7777-7777-7777-777777777777"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Upload purchase documentation", false, "Document", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), false, "receipt", 7, "Purchase Receipt" },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Name of the supply item", true, "SingleLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "product_name", 1, "Product Name" },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Current stock count", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "quantity", 2, "Quantity in Stock" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Minimum stock before reorder", true, "Numeric", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, "reorder_point", 3, "Reorder Point" },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Supplier contact and ordering details", false, "MultiLine", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), false, "supplier_info", 4, "Supplier Information" },
                    { new Guid("e1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Vehicle registration number", true, "SingleLine", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "license_plate", 1, "License Plate" },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Odometer reading", true, "Numeric", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "mileage", 2, "Current Mileage" },
                    { new Guid("e3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Current insurance status", true, "Boolean", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), true, "insurance_active", 3, "Insurance Active" },
                    { new Guid("e4444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "Annual inspection reports", false, "Document", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), false, "inspection_docs", 4, "Inspection Documents" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomId", "DeletedAt", "InventoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-001", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 2, 17, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-LAPTOP-002", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 2, 17, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "IT-MON-001", null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 27, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-A4-PAPER", null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 3, 1, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 26, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "SUP-TONER-BLK", null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 28, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) },
                    { new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 23, 19, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198), "99997999-7b3e-418f-9f53-38ec31c09abb", "VH-001", null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2026, 3, 2, 14, 43, 21, 272, DateTimeKind.Utc).AddTicks(2198) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventories_CreatedBy",
                table: "inventories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_inventories_accesses_InventoryId",
                table: "inventories_accesses",
                column: "InventoryId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "inventories_accesses");

            migrationBuilder.DropTable(
                name: "item_field_values");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "inventory_fields");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
