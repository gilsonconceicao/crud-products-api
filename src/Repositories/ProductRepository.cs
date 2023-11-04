using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;
using Microsoft.EntityFrameworkCore;

namespace crud_products_api.src.Repositories;

public class ProductRepository : BaseRepository<Product>, IProduct
{
#nullable disable
    private DataBaseContext _context;
    private IMapper _mapper;

    public ProductRepository(DataBaseContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    // public async Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product)
    // {
    //     product.Name = updatedProduct.Name;
    //     product.Description = updatedProduct.Description;
    //     product.Price = updatedProduct.Price; ;
    //     product.Category = updatedProduct.Category;
    //     product.Discount = updatedProduct.Discount;
    //     product.TotalValue = updatedProduct.Price! + updatedProduct.Discount;
    //     product.UpdatedAt = DateTime.UtcNow;

    //     if (updatedProduct.Address != null)
    //     {
    //         if (product.Address is null)
    //         {
    //             Address addressCreated = _mapper.Map<Address>(updatedProduct.Address);
    //             addressCreated.ProductId = product.Id;
    //             await _context.Address.AddAsync(addressCreated);
    //         }
    //         else
    //         {
    //             product.Address.State = updatedProduct.Address.State;
    //             product.Address.City = updatedProduct.Address.City;
    //             product.Address.ZipCode = updatedProduct.Address.ZipCode;
    //             product.Address.Street = updatedProduct.Address.Street;
    //         }
    //     }
    // }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
#nullable restore
}