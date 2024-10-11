using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;

namespace Billder.API.Repositories.Classes
{
    public class GastosRepository : GenericRepository<Gasto>, IGastosRepository
    {
        public GastosRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task CreateGastos(List<Gasto> gastos)
        {
            await _dbSet.AddRangeAsync(gastos);

            await _dbContext.SaveChangesAsync();
        }
    }
}
