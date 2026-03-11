using ITask7.Models.Chat;
using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.TEMP;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace ITask7.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryField> InventoryFields { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemFieldValue> ItemFieldValues { get; set; }
    public DbSet<InventoryAccess> InventoryAccesses { get; set; }
    public DbSet<InventoryMessage> InventoryMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.IsPublic).HasDefaultValue("FALSE");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.Sequential).HasDefaultValue(0);
            entity.Property(e => e.RowVersion).IsRowVersion();

            entity.HasOne(e => e.Creator)
                .WithMany(u => u.CreatedInventories)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);
        });
        
        modelBuilder.Entity<InventoryField>(entity =>
        {
            entity.ToTable("inventory_fields");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.RowVersion).IsRowVersion();
            
            entity.Property(e => e.FieldType)
                .HasConversion<string>()
                .HasMaxLength(20); 
            
            entity.HasIndex(e => new { e.InventoryId, e.Name }).IsUnique();
            entity.HasIndex(e => new { e.InventoryId, e.SortOrder });
            
            entity.HasOne(e => e.Inventory)
                .WithMany(i => i.Fields)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("items");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.RowVersion).IsRowVersion();
            
            entity.HasIndex(e => new { e.InventoryId, e.CustomId })
                .IsUnique();
            
            entity.HasIndex(e => e.InventoryId);
            
            entity.HasOne(e => e.Inventory)
                .WithMany(i => i.Items)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(e => e.Creator)
                .WithMany(c => c.CreatedItems)
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull);
        });
        
        modelBuilder.Entity<ItemFieldValue>(entity =>
        {
            entity.ToTable("item_field_values");
            entity.HasKey(e => e.Id); // TODO: has key {fieldId & itemId}
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW()");
            
            entity.HasIndex(e => new { e.ItemId, e.FieldId }).IsUnique();
            
            entity.HasOne(e => e.Item)
                .WithMany(i => i.FieldValues)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Field)
                .WithMany(f => f.Values)
                .HasForeignKey(e => e.FieldId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<InventoryAccess>(entity =>
        {
            entity.ToTable("inventories_accesses");
            entity.HasKey(e => new { e.UserId, e.InventoryId });
            entity.HasOne(e => e.User)
                .WithMany(u => u.Accesses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Inventory)
                .WithMany(i => i.Accesses)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .HasMethod("BTree")
            .HasOperators("varchar_pattern_ops");
        
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.IsBlocked).HasDefaultValue(false);
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<InventoryMessage>(entity =>
        {
            entity.ToTable("messages");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            
            entity.HasOne(e => e.Inventory)
                .WithMany(i => i.Messages)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(e => e.Sender)
                .WithMany(u => u.Messages)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}