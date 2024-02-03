using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;

namespace StudentsManagement.Services
{


    public class GenericRepository<TContext> : IGenericRepository where TContext : DbContext
    {
        private readonly TContext _context;
        public  GenericRepository(TContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        public async Task<TEntity> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
             _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
