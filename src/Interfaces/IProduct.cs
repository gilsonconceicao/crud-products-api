using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        Task<List<ProductReadModel>> GetAllProducts();
        Task CreateProductAsync(ProductCreateModel product);
        Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product);
        Product GetProductByIdAsync(Guid id);
        void DeleteProductAsync(Product product); 
        Task SaveChangesAsync();
    }
}