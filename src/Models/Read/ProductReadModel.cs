using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;
using crud_products_api.src.Models.Create;

namespace crud_products_api.src.Models.Read;
public class ProductReadModel
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Name { get; set; } 
    public Category Category { get; set; }
    public string CategoryDisplay { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
    public double Discount { get; set; }
    public DateTime DiscountExpirationDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public AddressReadModel Address { get; set; }
}
