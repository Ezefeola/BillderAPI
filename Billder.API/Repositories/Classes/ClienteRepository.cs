using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Repositories.Classes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Cliente>> GetAllUserCustomers(int userId)
        {
            List<Cliente> customers = await _dbSet.Where(x => x.UsuarioId == userId).ToListAsync();

            return customers;
        }
    }
}
