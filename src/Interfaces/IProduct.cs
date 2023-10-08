using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        List<ProductReadModel> GetAllProducts();
        Task CreateProductAsync(ProductCreateModel product); 
        Task SaveChangesAsync();
    }
}