using Billder.API.Models;

namespace Billder.API.Repositories.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<List<Cliente>> GetAllUserCustomers(int userId);
    }
}
