using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Models;

namespace crud_products_api.src.Interfaces
{
    public class IEntityRepository
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}