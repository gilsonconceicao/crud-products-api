namespace crud_products_api.src.Models;
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Name { get; set; } 
    public string Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int? StockQuantity { get; set; }
    public double? Discount { get; set; }
    public DateTime? DiscountExpirationDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public Address? Address { get; set; }
}