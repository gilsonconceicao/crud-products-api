

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
}
