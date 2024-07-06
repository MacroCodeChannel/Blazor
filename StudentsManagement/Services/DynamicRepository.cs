using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Models;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public class DynamicRepository: IDynamicRepository
    {
        private readonly ApplicationDbContext _context;

        public DynamicRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Complaint>> GetAllComplaints()
        {
            var data = await _context.Complaints
                .Include(x=>x.ComplaintType)
                .Include(x => x.Status)
                .ToListAsync();  
           
            return data;
        }
    }
}
