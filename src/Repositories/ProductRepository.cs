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
using Microsoft.EntityFrameworkCore;

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
        var products = _context
            .Products
            .ToList();
        return _mapper.Map<List<ProductReadModel>>(products);
    }

    public Product GetProductByIdAsync(Guid id)
    {
        Product product = _context.Products.FirstOrDefault(p => p.Id == id);
        return product; 
    }

    public async Task CreateProductAsync(ProductCreateModel product)
    {
        Product productCreated = _mapper.Map<ProductCreateModel, Product>(product);
        await _context.Products.AddAsync(productCreated);
    }


    public async Task UpdateProductAsync(ProductUpdateModel updatedProduct, Product product)
    {
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price; ;
        product.Category = updatedProduct.Category; 
        product.Discount = updatedProduct.Discount;
        product.UpdatedAt = DateTime.UtcNow; 
        
        if (updatedProduct.Address != null)
        {
            if (product.Address is null)
            {
                Address addressCreated = _mapper.Map<Address>(updatedProduct.Address);
                addressCreated.ProductId = product.Id; 
                // product.Address = addressCreated;
                await _context.Address.AddAsync(addressCreated); 
            }
            else
            {
                product.Address.State = updatedProduct.Address.State;
                product.Address.City = updatedProduct.Address.City ;
                product.Address.ZipCode = updatedProduct.Address.ZipCode;
                product.Address.Street = updatedProduct.Address.Street; 
            }
        }
    }

    public void DeleteProductAsync(Product product) 
    {
        _context.Products.Remove(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
