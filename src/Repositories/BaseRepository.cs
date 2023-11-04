using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Contexts;
using crud_products_api.src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud_products_api.src.Repositories
{
#nullable disable
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntityRepository
    {
        private readonly DataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public BaseRepository(DataBaseContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var list = await _dbContext.Set<TEntity>().ToListAsync();
            return list;
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            TEntity find = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == Id);
            return find;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, TEntity newEntity)
        {
            newEntity.Id = entity.Id;
            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
#nullable restore
}