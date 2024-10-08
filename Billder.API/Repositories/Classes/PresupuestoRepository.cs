using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;

namespace Billder.API.Repositories.Classes
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>, IPresupuestoRepository
    {
        public PresupuestoRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
