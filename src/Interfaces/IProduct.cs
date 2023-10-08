using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        List<ProductReadModel> GetAllProducts();
        Task<ProductCreateModel> CreateProduct(ProductCreateModel product); 
        Task saveChangesAsync();
    }
}