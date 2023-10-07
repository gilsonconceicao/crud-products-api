using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Models;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
    }
}