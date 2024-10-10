using Billder.API.Models;

namespace Billder.API.Services.Interfaces
{
    public interface IClienteService : IGenericService<Cliente>
    {
        Task<List<Cliente>> GetAllUserCustomersAsync(int userId);
    }
}
