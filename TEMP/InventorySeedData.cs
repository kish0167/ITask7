using ITask7.Models.Inventories;
using Microsoft.EntityFrameworkCore;
using ITask7.Users;

namespace ITask7.TEMP;

public static class InventorySeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow;
        var adminUserId = "99997999-7b3e-418f-9f53-38ec31c09abb";
        
        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            UserName = "admin@company.com",
            NormalizedUserName = "ADMIN@COMPANY.COM",
            Email = "admin@company.com",
            NormalizedEmail = "ADMIN@COMPANY.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D")
        };
        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
        
        // ========== INVENTORY 1: IT Asset Management ==========
        var itInventoryId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        
        modelBuilder.Entity<Inventory>().HasData(new Inventory
        {
            Id = itInventoryId,
            Name = "IT Equipment",
            Description = "Track laptops, monitors, peripherals, and other IT assets",
            CreatedBy = adminUserId,
            CreatedAt = now,
            UpdatedAt = now
        });

        var itFields = new[]
        {
            new InventoryField 
            { 
                Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"),
                InventoryId = itInventoryId,
                Name = "asset_tag",
                Title = "Asset Tag",
                Description = "Physical asset tag number",
                FieldType = FieldType.SingleLine,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 1,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a2222222-2222-2222-2222-222222222222"),
                InventoryId = itInventoryId,
                Name = "serial_number",
                Title = "Serial Number",
                Description = "Manufacturer serial number",
                FieldType = FieldType.SingleLine,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 2,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a3333333-3333-3333-3333-333333333333"),
                InventoryId = itInventoryId,
                Name = "purchase_price",
                Title = "Purchase Price",
                Description = "Original purchase price in USD",
                FieldType = FieldType.Numeric,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 3,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a4444444-4444-4444-4444-444444444444"),
                InventoryId = itInventoryId,
                Name = "warranty_expires",
                Title = "Warranty Expires",
                Description = "Warranty expiration date",
                FieldType = FieldType.SingleLine, // Could be Date type if you add it
                IsRequired = false,
                DisplayInTable = false,
                SortOrder = 4,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a5555555-5555-5555-5555-555555555555"),
                InventoryId = itInventoryId,
                Name = "is_assigned",
                Title = "Assigned",
                Description = "Currently assigned to employee",
                FieldType = FieldType.Boolean,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 5,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a6666666-6666-6666-6666-666666666666"),
                InventoryId = itInventoryId,
                Name = "notes",
                Title = "Notes",
                Description = "Additional information",
                FieldType = FieldType.MultiLine,
                IsRequired = false,
                DisplayInTable = false,
                SortOrder = 6,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("a7777777-7777-7777-7777-777777777777"),
                InventoryId = itInventoryId,
                Name = "receipt",
                Title = "Purchase Receipt",
                Description = "Upload purchase documentation",
                FieldType = FieldType.Document,
                IsRequired = false,
                DisplayInTable = false,
                SortOrder = 7,
                CreatedAt = now
            }
        };
        modelBuilder.Entity<InventoryField>().HasData(itFields);

        // IT Items
        var laptop1Id = Guid.Parse("b1111111-1111-1111-1111-111111111111");
        var laptop2Id = Guid.Parse("b2222222-2222-2222-2222-222222222222");
        var monitorId = Guid.Parse("b3333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Item>().HasData(
            new Item 
            { 
                Id = laptop1Id, 
                InventoryId = itInventoryId,
                CustomId = "IT-LAPTOP-001",
                CreatedBy = adminUserId,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Item 
            { 
                Id = laptop2Id, 
                InventoryId = itInventoryId,
                CustomId = "IT-LAPTOP-002",
                CreatedBy = adminUserId,
                CreatedAt = now.AddHours(-2),
                UpdatedAt = now.AddHours(-2)
            },
            new Item 
            { 
                Id = monitorId, 
                InventoryId = itInventoryId,
                CustomId = "IT-MON-001",
                CreatedBy = adminUserId,
                CreatedAt = now.AddDays(-1),
                UpdatedAt = now.AddDays(-1)
            }
        );

        // IT Field Values
        modelBuilder.Entity<ItemFieldValue>().HasData(
            // Laptop 1
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[0].Id, ValueText = "AST-2024-001", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[1].Id, ValueText = "SN123456789", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[2].Id, ValueNumeric = 1299.99m, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[3].Id, ValueText = "2027-03-15", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[4].Id, ValueBoolean = true, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop1Id, FieldId = itFields[5].Id, ValueText = "Assigned to Engineering team lead", CreatedAt = now, UpdatedAt = now },
            
            // Laptop 2
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop2Id, FieldId = itFields[0].Id, ValueText = "AST-2024-002", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop2Id, FieldId = itFields[1].Id, ValueText = "SN987654321", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop2Id, FieldId = itFields[2].Id, ValueNumeric = 1599.50m, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop2Id, FieldId = itFields[3].Id, ValueText = "2027-06-20", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = laptop2Id, FieldId = itFields[4].Id, ValueBoolean = false, CreatedAt = now, UpdatedAt = now },
            
            // Monitor
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = monitorId, FieldId = itFields[0].Id, ValueText = "AST-2023-045", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = monitorId, FieldId = itFields[1].Id, ValueText = "DELL-SN-778899", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = monitorId, FieldId = itFields[2].Id, ValueNumeric = 349.00m, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = monitorId, FieldId = itFields[4].Id, ValueBoolean = true, CreatedAt = now, UpdatedAt = now }
        );

        // ========== INVENTORY 2: Office Supplies ==========
        var officeInventoryId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        
        modelBuilder.Entity<Inventory>().HasData(new Inventory
        {
            Id = officeInventoryId,
            Name = "Office Supplies",
            Description = "Track stationery, printer supplies, and office consumables",
            CreatedBy = adminUserId,
            CreatedAt = now.AddDays(-5),
            UpdatedAt = now.AddDays(-5)
        });

        var officeFields = new[]
        {
            new InventoryField 
            { 
                Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                InventoryId = officeInventoryId,
                Name = "product_name",
                Title = "Product Name",
                Description = "Name of the supply item",
                FieldType = FieldType.SingleLine,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 1,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("c2222222-2222-2222-2222-222222222222"),
                InventoryId = officeInventoryId,
                Name = "quantity",
                Title = "Quantity in Stock",
                Description = "Current stock count",
                FieldType = FieldType.Numeric,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 2,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("c3333333-3333-3333-3333-333333333333"),
                InventoryId = officeInventoryId,
                Name = "reorder_point",
                Title = "Reorder Point",
                Description = "Minimum stock before reorder",
                FieldType = FieldType.Numeric,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 3,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("c4444444-4444-4444-4444-444444444444"),
                InventoryId = officeInventoryId,
                Name = "supplier_info",
                Title = "Supplier Information",
                Description = "Supplier contact and ordering details",
                FieldType = FieldType.MultiLine,
                IsRequired = false,
                DisplayInTable = false,
                SortOrder = 4,
                CreatedAt = now
            }
        };
        modelBuilder.Entity<InventoryField>().HasData(officeFields);

        // Office Items
        var paperId = Guid.Parse("d1111111-1111-1111-1111-111111111111");
        var tonerId = Guid.Parse("d2222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<Item>().HasData(
            new Item 
            { 
                Id = paperId, 
                InventoryId = officeInventoryId,
                CustomId = "SUP-A4-PAPER",
                CreatedBy = adminUserId,
                CreatedAt = now.AddDays(-3),
                UpdatedAt = now.AddDays(-1)
            },
            new Item 
            { 
                Id = tonerId, 
                InventoryId = officeInventoryId,
                CustomId = "SUP-TONER-BLK",
                CreatedBy = adminUserId,
                CreatedAt = now.AddDays(-4),
                UpdatedAt = now.AddDays(-2)
            }
        );

        // Office Field Values
        modelBuilder.Entity<ItemFieldValue>().HasData(
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = paperId, FieldId = officeFields[0].Id, ValueText = "A4 Copy Paper (500 sheets)", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = paperId, FieldId = officeFields[1].Id, ValueNumeric = 45, CreatedAt = now, UpdatedAt = now.AddDays(-1) },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = paperId, FieldId = officeFields[2].Id, ValueNumeric = 10, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = paperId, FieldId = officeFields[3].Id, ValueText = "Staples Inc. - staples.com - Account #12345", CreatedAt = now, UpdatedAt = now },
            
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = tonerId, FieldId = officeFields[0].Id, ValueText = "HP LaserJet Black Toner 85A", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = tonerId, FieldId = officeFields[1].Id, ValueNumeric = 3, CreatedAt = now, UpdatedAt = now.AddDays(-2) },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = tonerId, FieldId = officeFields[2].Id, ValueNumeric = 2, CreatedAt = now, UpdatedAt = now }
        );

        // ========== INVENTORY 3: Vehicle Fleet ==========
        var fleetInventoryId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        
        modelBuilder.Entity<Inventory>().HasData(new Inventory
        {
            Id = fleetInventoryId,
            Name = "Vehicle Fleet",
            Description = "Company vehicles and maintenance records",
            CreatedBy = adminUserId,
            CreatedAt = now.AddDays(-10),
            UpdatedAt = now.AddDays(-10)
        });

        var fleetFields = new[]
        {
            new InventoryField 
            { 
                Id = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                InventoryId = fleetInventoryId,
                Name = "license_plate",
                Title = "License Plate",
                Description = "Vehicle registration number",
                FieldType = FieldType.SingleLine,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 1,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("e2222222-2222-2222-2222-222222222222"),
                InventoryId = fleetInventoryId,
                Name = "mileage",
                Title = "Current Mileage",
                Description = "Odometer reading",
                FieldType = FieldType.Numeric,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 2,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("e3333333-3333-3333-3333-333333333333"),
                InventoryId = fleetInventoryId,
                Name = "insurance_active",
                Title = "Insurance Active",
                Description = "Current insurance status",
                FieldType = FieldType.Boolean,
                IsRequired = true,
                DisplayInTable = true,
                SortOrder = 3,
                CreatedAt = now
            },
            new InventoryField 
            { 
                Id = Guid.Parse("e4444444-4444-4444-4444-444444444444"),
                InventoryId = fleetInventoryId,
                Name = "inspection_docs",
                Title = "Inspection Documents",
                Description = "Annual inspection reports",
                FieldType = FieldType.Document,
                IsRequired = false,
                DisplayInTable = false,
                SortOrder = 4,
                CreatedAt = now
            }
        };
        modelBuilder.Entity<InventoryField>().HasData(fleetFields);

        // Fleet Item
        var vanId = Guid.Parse("f1111111-1111-1111-1111-111111111111");

        modelBuilder.Entity<Item>().HasData(
            new Item 
            { 
                Id = vanId, 
                InventoryId = fleetInventoryId,
                CustomId = "VH-001",
                CreatedBy = adminUserId,
                CreatedAt = now.AddDays(-7),
                UpdatedAt = now.AddHours(-5)
            }
        );

        // Fleet Field Values
        modelBuilder.Entity<ItemFieldValue>().HasData(
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = vanId, FieldId = fleetFields[0].Id, ValueText = "ABC-1234", CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = vanId, FieldId = fleetFields[1].Id, ValueNumeric = 45230, CreatedAt = now, UpdatedAt = now.AddHours(-5) },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = vanId, FieldId = fleetFields[2].Id, ValueBoolean = true, CreatedAt = now, UpdatedAt = now },
            new ItemFieldValue { Id = Guid.NewGuid(), ItemId = vanId, FieldId = fleetFields[3].Id, ValueDocumentUrl = "/docs/inspections/van-2024.pdf", CreatedAt = now, UpdatedAt = now }
        );
    }
}