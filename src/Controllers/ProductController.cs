using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Enums;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;
using crud_products_api.src.Repositories;
using crud_products_api.src.Utility.Validations;
using Microsoft.AspNetCore.Mvc;

namespace crud_products_api.src.Controllers;
[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductController(DataBaseContext context, IMapper mapper)
    {
        _productRepository = new ProductRepository(context, mapper);
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todos os produtos
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductReadModel>))]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var productsList = await _productRepository.GetAllProductsAsync();
            return Ok(productsList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Recupera um produto específico
    /// </summary>
    /// <param name="Id">Id do produto</param>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [HttpGet("{Id}")]
    public async Task<ActionResult> GetProductById(Guid Id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(Id);
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
            Console.WriteLine("Exception: " + ex);
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um novo produto
    /// </summary>
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductCreateModel))]
    [HttpPost()]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateModel product)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Informações inválidas"
                });
            }

            Product productCreated = _mapper.Map<ProductCreateModel, Product>(product);
            await _productRepository.AddAsync(productCreated);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] ProductUpdateModel updateProduct)
    {
        try
        {
            Product product = await _productRepository.GetByIdAsync(Id);
            if (product is null)
            {
                return NotFound(new
                {
                    message = "Product " + Id + " does not exist"
                });
            }

            await _productRepository.UpdateProductById(product, updateProduct);
            // await _productRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Remove um produto 
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductCreateModel))]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(Id);
            if (product is null)
            {
                return NotFound(new
                {
                    message = "Product " + Id + " does not exist"
                });
            }
            await _productRepository.DeleteAsync(product);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}
