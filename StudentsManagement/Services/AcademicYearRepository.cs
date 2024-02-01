using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Models;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly ApplicationDbContext _context;

        public AcademicYearRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<AcademicYear> AddAsync(AcademicYear mod)
        {
            if (mod == null) return null;

            var activestatus = await _context.SystemCodeDetails
              .Include(x => x.SystemCode)
              .Where(x => x.SystemCode.Code == "AcademicYearStatus" && x.Code == "Active")
              .FirstOrDefaultAsync();

            mod.StatusId = activestatus.Id;
            var data = _context.AcademicYears.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<AcademicYear> DeleteAsync(int id)
        {
            var data = await _context.AcademicYears.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.AcademicYears.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<AcademicYear>> GetAllAsync()
        {
            var data = await _context.AcademicYears
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .Include(x => x.Status)
                .ToListAsync();

            return data;
        }

        public async Task<AcademicYear> GetByIdAsync(int id)
        {
            var data = await _context.AcademicYears.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<AcademicYear> UpdateAsync(AcademicYear mod)
        {
            if (mod == null) return null;

            var data = _context.AcademicYears.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
