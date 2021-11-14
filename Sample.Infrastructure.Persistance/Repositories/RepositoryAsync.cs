using Microsoft.EntityFrameworkCore;
using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using Sample.Infrastructure.Persistance.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Persistance.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationContext _dbContext;

        public RepositoryAsync(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            T item = await _dbContext.Set<T>().FindAsync(entity.Id);
            _dbContext.Entry(item).CurrentValues.SetValues(entity);
        }
        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();
    }
}
