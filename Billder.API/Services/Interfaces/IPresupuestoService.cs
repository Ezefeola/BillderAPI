using Billder.API.Models;

namespace Billder.API.Services.Interfaces
{
    public interface IPresupuestoService : IGenericService<Presupuesto>
    {
        Task<List<Presupuesto>> GetAlljobBudgetsAsync(int jobId);
        Task CreateGastosAsync(List<Gasto> gastos);
    }
}
