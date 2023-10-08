using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Models.Create;

public class ProductCreateModel
{
    public string Name { get; set; } 
    public string Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Address Address { get; set; }
}
