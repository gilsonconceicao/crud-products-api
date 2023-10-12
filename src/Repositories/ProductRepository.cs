using System;
using System.Data.Entity;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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
    public async Task<Product> GetProductByIdAsync(Guid id) 
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id); 
    }

    public List<ProductReadModel> GetAllProducts()
    {
        var products = _context
            .Products
            .Include(p => p.Address)
            .ToList();
        return _mapper.Map<List<ProductReadModel>>(products);
    }

    public async Task CreateProductAsync(ProductCreateModel product)
    {
        Product productCreated = _mapper.Map<ProductCreateModel, Product>(product);
        await _context.Products.AddAsync(productCreated);
    }


    public async Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product)
    {

    }


    public async Task DeleteProductAsync(Product product) 
    {

    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
