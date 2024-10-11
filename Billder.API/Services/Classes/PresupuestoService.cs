using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;

namespace Billder.API.Services.Classes
{
    public class PresupuestoService : GenericService<Presupuesto>, IPresupuestoService
    {
        private readonly IPresupuestoRepository _presupuestoRepository;
        private readonly IGastosRepository _gastosRepository;

        public PresupuestoService(IPresupuestoRepository presupuestoRepository, IGastosRepository gastosRepository) : base(presupuestoRepository)
        {
            _presupuestoRepository = presupuestoRepository;
            _gastosRepository = gastosRepository;
        }

        public async Task<List<Presupuesto>> GetAlljobBudgetsAsync(int jobId)
        {
            return await _presupuestoRepository.GetAlljobBudgets(jobId);
        }

        public async Task CreateGastosAsync(List<Gasto> gastos)
        {
            await _gastosRepository.CreateGastos(gastos);
        }
    }
}
