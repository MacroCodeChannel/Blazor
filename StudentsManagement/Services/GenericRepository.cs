using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public class GenericRepository<TContext> : IGenericRepository where TContext : DbContext
    {
        private readonly TContext _context;

        private readonly IUnitOfwork _unitOfWork;

        public GenericRepository(TContext applicationDbContext, IUnitOfwork unitOfWork) 
        {

            _context = applicationDbContext;
            _unitOfWork = unitOfWork;
        }  
        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();  
            return entity;  
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
             _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
             _context.Attach(entity);
             _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
