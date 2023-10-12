using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Models;
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
    public ProductController(DataBaseContext context, IMapper mapper)
    {
        _productRepository = new ProductRepository(context, mapper);
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
    /// Recupera um produto por id
    /// </summary>
    /// <param name="Id">Id do produto</param>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductReadModel>))]
    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> GetProductById(Guid Id)
    {
        try
        {
            var product = await _productRepository.GetProductByIdAsync(Id);
            if (product is null)
            {
                return NotFound(new
                {
                    message = "Product " + Id + " does not exist"
                });
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: "+ex); 
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
        try
        {
            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}
