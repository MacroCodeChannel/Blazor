using StudentsManagement.Client.Models;
using StudentsManagement.Client.ViewModels;

namespace StudentsManagement.Client.Repository
{
    public interface IUserRepository
    {
        Task<RegisterUserViewModel> AddAsync(RegisterUserViewModel mod);

        Task<ApplicationUser> UpdateAsync(ApplicationUser mod);

        Task<ApplicationUser> DeleteAsync(string id);

        Task<List<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
