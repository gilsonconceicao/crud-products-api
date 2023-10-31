using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid Id);
}
