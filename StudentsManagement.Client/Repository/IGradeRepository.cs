using StudentsManagement.Client.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IGradeRepository
    {
        Task<Grade> AddAsync(Grade mod);

        Task<Grade> UpdateAsync(Grade mod);

        Task<Grade> DeleteAsync(int id);

        Task<List<Grade>> GetAllAsync();

        Task<Grade> GetByIdAsync(int id);
    }
}
