using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;

namespace Billder.API.Repositories.Classes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
