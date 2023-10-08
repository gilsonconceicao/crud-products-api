using System.Data.Entity;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Repositories;

public class ProductRepository : IProduct
{
    private DataBaseContext _context;
    private IMapper _mapper;
    public ProductRepository(DataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ProductReadModel> GetAllProducts()
    {
        var products = _mapper.Map<List<ProductReadModel>>(
            _context
            .Products
            .Include(p => p.Address)
            .ToList()
        );
        return products;
    }

    public async Task CreateProductAsync(ProductCreateModel product)
    {
        Product productCreated = _mapper.Map<ProductCreateModel, Product>(product);
        await _context.Products.AddAsync(productCreated);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
