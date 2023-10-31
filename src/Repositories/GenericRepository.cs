using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud_products_api.src.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IEntity
{
    private readonly DataBaseContext _dbContext; 
    private readonly IMapper _mapper; 
    public GenericRepository(DataBaseContext dataBaseContext, IMapper mapper)
    {
        _dbContext = dataBaseContext;
        _mapper = mapper; 
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid Id)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == Id);
    }
}
