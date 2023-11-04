using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;

namespace crud_products_api.src.Interfaces
{
    public interface IProduct
    {
        Task AddComment(ReviewCreateModel comment, Product product);
        void EditCommentById(ReviewCreateModel comment, Review review);
        Task CreateProductAsync(ProductCreateModel product);
        Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product);
        Task<Review> GetCommentById(Guid id);
        Task SaveChangesAsync();
    }
}