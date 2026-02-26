using ITask7.Models.Inventories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryField> InventoryFields { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemFieldValue> ItemFieldValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<FieldType>("field_type");
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW()");
        });
        
        modelBuilder.Entity<InventoryField>(entity =>
        {
            entity.ToTable("inventory_fields");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            
            entity.Property(e => e.FieldType)
                .HasConversion<string>()
                .HasMaxLength(20); 
            
            //entity.Property(e => e.ValidationRules)
            //    .HasColumnType("jsonb");
            
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
            
            entity.HasIndex(e => e.CustomId).IsUnique();
            entity.HasIndex(e => e.InventoryId);
            
            entity.HasOne(e => e.Inventory)
                .WithMany(i => i.Items)
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ItemFieldValue configuration
        modelBuilder.Entity<ItemFieldValue>(entity =>
        {
            entity.ToTable("item_field_values");
            entity.HasKey(e => e.Id);
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
    }
}