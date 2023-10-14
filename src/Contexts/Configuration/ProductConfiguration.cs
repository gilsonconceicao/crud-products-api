using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(p => p.Address)
            .WithOne(p => p.Product)
            .HasForeignKey<Address>(p => p.ProductId);

        builder
            .HasMany(e => e.Reviews)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId);
    }
}