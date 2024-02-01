namespace StudentsManagement.Client.Repository
{
    public interface IGenericRepository
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
