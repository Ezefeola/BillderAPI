using Billder.API.Models;

namespace Billder.API.Repositories.Interfaces
{
    public interface IPresupuestoRepository : IGenericRepository<Presupuesto>
    {
        Task<List<Presupuesto>> GetAlljobBudgets(int jobId);
    }
}
