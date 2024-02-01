using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Client.Models;

namespace StudentsManagement.Services
{
    public class BooksIssuanceRepository : IBooksIssuanceRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksIssuanceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<BookIssuance> AddAsync(BookIssuance mod)
        {
            var issuesstataus = await _context.SystemCodeDetails
                .Include(x => x.SystemCode)
                .Where(x => x.SystemCode.Code == "BookIssuanceStatus" && x.Code == "Issued")
                .FirstOrDefaultAsync();

            mod.StatusId = issuesstataus.Id;
            if (mod == null) return null;

            var data = _context.BookIssuanceHistory.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<BookIssuance> DeleteAsync(int id)
        {
            var data = await _context.BookIssuanceHistory.Include(x => x.CreatedBy).Include(x => x.ModifiedBy).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.BookIssuanceHistory.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<BookIssuance>> GetAllAsync()
        {
            var data = await _context.BookIssuanceHistory
                .Include(x => x.Student)
                .Include(x => x.Class)
                .Include(x => x.Book)
                .Include(x => x.Status)
                .Include(x => x.CreatedBy)
                .ToListAsync();

            return data;
        }

        public async Task<BookIssuance> GetByIdAsync(int id)
        {
            var data = await _context.BookIssuanceHistory
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<BookIssuance> UpdateAsync(BookIssuance mod)
        {
            if (mod == null) return null;

            var data = _context.BookIssuanceHistory.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<BookIssuance> ReturnBookUpdateAsync(BookIssuance mod)
        {
            if (mod == null) return null;

            var returnedstatus = await _context.SystemCodeDetails
               .Include(x => x.SystemCode)
               .Where(x => x.SystemCode.Code == "BookIssuanceStatus" && x.Code == "Returned")
               .FirstOrDefaultAsync();

            mod.StatusId = returnedstatus.Id;
            var data = _context.BookIssuanceHistory.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
