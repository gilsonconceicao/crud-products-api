using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;

namespace crud_products_api.src.Repositories;

public class ReviewRepository : BaseRepository<Review>, IReviewRepository
{
    private readonly DataBaseContext _context; 
    private readonly IMapper _mapper; 
    public ReviewRepository(DataBaseContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context; 
        _mapper = mapper;
    }

    public async Task AddAsyncReview(ReviewCreateModel review, Product product)
    {
        Review reviewCreated = _mapper.Map<Review>(review);
        product.Reviews.Add(reviewCreated);
        await _context.Review.AddAsync(reviewCreated); 
        await _context.SaveChangesAsync();
    }
}
