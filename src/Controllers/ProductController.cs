using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crud_products_api.src.Controllers;
[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;
    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Retorna todos os produtos
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductReadModel>))]
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        try
        {
            var productsList = _productRepository.GetAllProducts();
            return Ok(productsList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um novo produto
    /// </summary>
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductCreateModel))]
    [HttpPost("/CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductCreateModel product)
    {
        await _productRepository.CreateProductAsync(product);
        await _productRepository.SaveChangesAsync();
        return Ok();
    }
}
