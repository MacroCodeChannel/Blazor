using StudentsManagement.Client.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IAcademicYearRepository
    {
        Task<AcademicYear> AddAsync(AcademicYear mod);

        Task<AcademicYear> UpdateAsync(AcademicYear mod);

        Task<AcademicYear> DeleteAsync(int id);

        Task<List<AcademicYear>> GetAllAsync();

        Task<AcademicYear> GetByIdAsync(int id);
    }
}
