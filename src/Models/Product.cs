using crud_products_api.src.Enums;
using crud_products_api.src.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace crud_products_api.src.Models;
public class Product: IEntityRepository
{
#nullable disable
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }
    public int? StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public virtual Address? Address { get; set; }
    public virtual List<Review> Reviews { get; set; }
#nullable restore
}
