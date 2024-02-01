using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Models;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public class GradeRepository :IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Grade> AddAsync(Grade mod)
        {

            if (mod == null) return null;

            var data = _context.Grades.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<Grade> DeleteAsync(int id)
        {
            var data = await _context.Grades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.Grades.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            var data = await _context.Grades
                 .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .ToListAsync();

            return data;
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            var data = await _context.Grades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<Grade> UpdateAsync(Grade mod)
        {
            if (mod == null) return null;

            var data = _context.Grades.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
