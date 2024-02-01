using StudentsManagement.Client.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> AddAsync(Department mod);

        Task<Department> UpdateAsync(Department mod);

        Task<Department> DeleteAsync(int id);

        Task<List<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int id);
    }
}
