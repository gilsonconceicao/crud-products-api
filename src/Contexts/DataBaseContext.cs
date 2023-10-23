

using crud_products_api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_products_api.src.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Review> Review { get; set; }
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}
