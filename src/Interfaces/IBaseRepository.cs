using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Interfaces
{
    public interface IBaseRepository<TEntity> 
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid Id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, TEntity entityToReplace);
        Task DeleteAsync(TEntity entity);
    }
}