using Billder.API.Models;

namespace Billder.API.Repositories.Interfaces
{
    public interface IGastosRepository : IGenericRepository<Gasto>
    {
        Task CreateGastos(List<Gasto> gastos);
    }
}
