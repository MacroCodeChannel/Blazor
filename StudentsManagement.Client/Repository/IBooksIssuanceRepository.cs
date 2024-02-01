using StudentsManagement.Client.Models;
using System.Threading.Tasks;

namespace StudentsManagement.Client.Repository
{
    public interface IBooksIssuanceRepository
    {
        Task<BookIssuance> AddAsync(BookIssuance mod);

        Task<BookIssuance> UpdateAsync(BookIssuance mod);

        Task<BookIssuance> DeleteAsync(int id);

        Task<List<BookIssuance>> GetAllAsync();

        Task<BookIssuance> GetByIdAsync(int id);

        Task<BookIssuance> ReturnBookUpdateAsync(BookIssuance mod);
        
    }
}
