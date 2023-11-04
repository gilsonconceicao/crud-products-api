using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Interfaces;

namespace crud_products_api.src.Models;

public class Review : IEntityRepository
{
    #nullable disable
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string Comment { get; set; }
#nullable restore
}
