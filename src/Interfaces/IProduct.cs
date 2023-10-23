using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        Task<List<ProductReadModel>> GetAllProducts();
        Task AddComment(ReviewCreateModel comment, Product product);
        Task DeleteComment(Review review);
        Task CreateProductAsync(ProductCreateModel product);
        Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Review> GetCommentById(Guid id);
        void DeleteProduct(Product product); 
        Task SaveChangesAsync();
    }
}