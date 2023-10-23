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
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var productsList = await _productRepository.GetAllProducts();
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductReadModel>))]
    [HttpGet("{Id}")]
    public async Task<ActionResult> GetProductById(Guid Id)
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
            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();
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
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductCreateModel))]
    [HttpPut("/UpdateProduct/{Id}")]
    public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] ProductUpdateModel updateProduct)
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

            await _productRepository.UpdateProductAsync(updateProduct, product); 
            await _productRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Adicionar um comentário no produto
    /// </summary>
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReviewCreateModel))]
    [HttpPost("/Product/Comment/{Id}")]
    public async Task<IActionResult> CreateCommentByProductId(Guid Id, [FromBody] ReviewCreateModel comment)
    {
        try
        {
            Product product = await _productRepository.GetProductByIdAsync(Id);
            if (product is null)
            {
                return NotFound(new
                {
                    message = "Produto não existe"
                });
            }

            await _productRepository.AddComment(comment, product);
            await _productRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    /// <summary>
    /// Remove um comentário de um produto
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductCreateModel))]
    [HttpDelete("/Product/Comment/{Id}")]
    public async Task<IActionResult> DeleteProductById(Guid Id)
    {
        try
        {
            Review comment = await _productRepository.GetCommentById(Id);
            if (comment is null)
            {
                return NotFound(new
                {
                    message = "Comentário não existe"
                });
            }

            await _productRepository.DeleteComment(comment);
            await _productRepository.SaveChangesAsync();
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
            var product = await _productRepository.GetProductByIdAsync(Id);
            if (product is null)
            {
                return NotFound(new
                {
                    message = "Product " + Id + " does not exist"
                });
            }
            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}
