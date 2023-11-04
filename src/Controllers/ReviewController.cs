using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crud_products_api.src.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly ReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(DataBaseContext context, IMapper mapper)
        {
            _reviewRepository = new ReviewRepository(context, mapper);
            _productRepository = new ProductRepository(context, mapper);
            _mapper = mapper; 
        }

        /// <summary>
        /// Recupera uma review específica
        /// </summary>
        /// <param name="Id">Id da review</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetReviewById(Guid Id)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(Id);
                if (review is null)
                {
                    return NotFound(new
                    {
                        message = $"Id informado não existe"
                    });
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova review no produto
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="modelReview"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
        [HttpPost("{ProductId}")]
        public async Task<ActionResult> CreateReviewBPerProduct(Guid ProductId, 
                                                                [FromBody] ReviewCreateModel modelReview)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(ProductId); 
                if (product == null)
                {
                    return BadRequest(new {
                        message = "Produto informado não existe"
                    }); 
                }

                await _reviewRepository.AddAsyncReview( modelReview, product );
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma review por id
        /// </summary>
        /// <param name="Id">Id da review</param>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateReviewById(Guid Id, ReviewCreateModel model)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(Id);
                if (review is null)
                {
                    return NotFound(new
                    {
                        message = $"Id informado não existe"
                    });
                }
                Review reviewBody = _mapper.Map<Review>(model);
                await _reviewRepository.UpdateAsync(review, reviewBody); 
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }

        /// <summary>
        ///Remove uma review por id
        /// </summary>
        /// <param name="Id">Id da review</param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteReviewById(Guid Id)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(Id);
                if (review is null)
                {
                    return NotFound(new
                    {
                        message = $"Id informado não existe"
                    });
                }

                await _reviewRepository.DeleteAsync(review); 
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }
    }
}