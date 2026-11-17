using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Core.Entities;

namespace WarehouseAccounting.Core.Data;

public class AppDbContext : DbContext
{
    public const string BaseCurrencyCode = "USD";

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehouseProduct> WarehouseProducts => Set<WarehouseProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(e =>
        {
            e.Property(c => c.Name).IsRequired().HasMaxLength(50);
            e.Property(c => c.Code).IsRequired().HasMaxLength(3);
            e.Property(c => c.Rate).HasPrecision(18, 6);
            e.HasIndex(c => c.Code).IsUnique();

            e.HasData(
                new Currency { Id = 1, Name = "Гривня", Code = "UAH", Rate = 41.5m },
                new Currency { Id = 2, Name = "Доллар", Code = BaseCurrencyCode, Rate = 1m },
                new Currency { Id = 3, Name = "Евро", Code = "EUR", Rate = 0.86m });
        });

        modelBuilder.Entity<Category>(e =>
        {
            e.Property(c => c.Name).IsRequired().HasMaxLength(100);
            e.HasIndex(c => c.Name).IsUnique();
        });

        modelBuilder.Entity<Product>(e =>
        {
            e.Property(p => p.Name).IsRequired().HasMaxLength(200);
            e.Property(p => p.Price).HasPrecision(18, 2);
            e.Property(p => p.PriceBase).HasPrecision(18, 2);
            e.Property(p => p.Barcode).IsRequired().HasMaxLength(8).IsFixedLength();
            e.HasIndex(p => p.Barcode).IsUnique();

            e.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            e.HasOne(p => p.Currency)
                .WithMany()
                .HasForeignKey(p => p.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Warehouse>(e =>
        {
            e.Property(w => w.Name).IsRequired().HasMaxLength(100);
            e.Property(w => w.Address).IsRequired().HasMaxLength(250);
        });

        modelBuilder.Entity<WarehouseProduct>(e =>
        {
            e.HasIndex(wp => new { wp.WarehouseId, wp.ProductId }).IsUnique();

            e.HasOne(wp => wp.Warehouse)
                .WithMany(w => w.Items)
                .HasForeignKey(wp => wp.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(wp => wp.Product)
                .WithMany()
                .HasForeignKey(wp => wp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
