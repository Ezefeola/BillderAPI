using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;

namespace Billder.API.Repositories.Classes
{
    public class TrabajoRepository : GenericRepository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
