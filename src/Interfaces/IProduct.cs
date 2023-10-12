using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        List<ProductReadModel> GetAllProducts();
        Task CreateProductAsync(ProductCreateModel product);
        Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product);
        Task<Product> GetProductByIdAsync(Guid id);
        Task DeleteProductAsync(Product product); 
        Task SaveChangesAsync();
    }
}