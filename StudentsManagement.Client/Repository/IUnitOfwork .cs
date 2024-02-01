using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Client.Repository
{
    public interface IUnitOfwork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}