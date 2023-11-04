using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductReadModel>> GetAllProductsAsync();
        Task UpdateProductById(Product product, ProductUpdateModel productUpdated);
    }
}