using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Models.Read
{
    public class ReviewReadModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Comment { get; set; }
         public DateTime CreatedAt { get; set; }
    }
}