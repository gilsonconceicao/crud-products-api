using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        Task<List<ProductReadModel>> GetAllProductsAsync();
        Task UpdateProductById(Product product, ProductUpdateModel productUpdated);
        // Task CreateProductAsync(ProductCreateModel product);
        // Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product);
        // Task SaveChangesAsync();
    }
    // Task AddComment(ReviewCreateModel comment, Product product);
    // void EditCommentById(ReviewCreateModel comment, Review review);
    // Task<Review> GetCommentById(Guid id);
}