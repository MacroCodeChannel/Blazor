using StudentsManagement.Client.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IDynamicRepository
    {
        Task<List<Complaint>> GetAllComplaints();
    }
}
