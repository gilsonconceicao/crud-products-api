

using crud_products_api.src.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace crud_products_api.src.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Address> Address { get; set; }
    public DataBaseContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Address)
            .WithOne(p => p.Product)
            .HasForeignKey<Address>(p => p.ProductId); 
    }
}
