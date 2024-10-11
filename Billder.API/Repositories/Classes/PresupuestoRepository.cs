using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Repositories.Classes
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>, IPresupuestoRepository
    {
        public PresupuestoRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
        }

        public async Task<List<Presupuesto>> GetAlljobBudgets(int jobId)
        {
            List<Presupuesto> jobBudgets = await _dbSet.Where(x => x.TrabajoId == jobId).ToListAsync();

            return jobBudgets;
        }
    }
}
