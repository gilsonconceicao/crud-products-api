using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        Task<List<ProductReadModel>> GetAllProducts();
        Task CreateProduct(ProductCreateModel product); 
        Task SaveChangesAsync();
    }
}