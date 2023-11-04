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
    private readonly DataBaseContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(DataBaseContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
        _context = context; 
    }

    public async Task<List<ProductReadModel>> GetAllProductsAsync()
    {
        var list = _context.Products.ToListAsync();
        return await _mapper.Map<Task<List<Product>>, Task<List<ProductReadModel>>>(list);
    }

    public Task<List<ProductReadModel>> UpdateProductById(Product product, ProductUpdateModel productUpdated)
    {
       
    }

#nullable restore
}