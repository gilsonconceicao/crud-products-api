using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;

namespace crud_products_api.src.Interfaces
{
    public interface IReviewRepository
    {
        Task AddAsyncReview(ReviewCreateModel review, Product product); 
    }
}