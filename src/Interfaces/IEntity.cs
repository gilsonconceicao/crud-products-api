using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Interfaces
{
    public class IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}