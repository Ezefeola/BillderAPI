using Billder.API.Models;

namespace Billder.API.Repositories.Interfaces
{
    public interface ITrabajoRepository : IGenericRepository<Trabajo>
    {
        Task<List<Trabajo>> GetAllCustomerJobs(int customerId);
    }
}
