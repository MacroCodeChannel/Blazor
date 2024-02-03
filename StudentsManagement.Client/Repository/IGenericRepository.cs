using StudentsManagement.Client.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IGenericRepository
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class;  

        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<TEntity> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
    }
}
