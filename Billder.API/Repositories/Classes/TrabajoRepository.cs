using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Repositories.Classes
{
    public class TrabajoRepository : GenericRepository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
                
        }

        public async Task<List<Trabajo>> GetAllCustomerJobs(int customerId)
        {
            List<Trabajo> jobs = await _dbSet.Where(x => x.ClienteId == customerId).ToListAsync();

            return jobs;
        }
    }
}
