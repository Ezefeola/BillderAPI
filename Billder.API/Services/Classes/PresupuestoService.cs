using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;

namespace Billder.API.Services.Classes
{
    public class PresupuestoService : GenericService<Presupuesto>, IPresupuestoService
    {
        private readonly IPresupuestoRepository presupuestoRepository;
        public PresupuestoService(IPresupuestoRepository presupuestoRepository) : base(presupuestoRepository)
        {
            this.presupuestoRepository = presupuestoRepository;
        }
    }
}
