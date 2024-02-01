using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Client.Models;
using System.Security.Claims;
using  Microsoft.AspNetCore.Identity;

namespace StudentsManagement.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Department> AddAsync(Department mod)
        {
            
            if (mod == null) return null;

            var data = _context.Departments.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<Department> DeleteAsync(int id)
        {
            var country = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (country == null) return null;

            _context.Departments.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var data = await _context.Departments
                 .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .ToListAsync();

            return data;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var data = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<Department> UpdateAsync(Department mod)
        {
            if (mod == null) return null;

            var data = _context.Departments.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
