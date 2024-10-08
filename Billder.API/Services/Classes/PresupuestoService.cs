﻿using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;

namespace Billder.API.Services.Classes
{
    public class PresupuestoService : GenericService<Presupuesto>, IPresupuestoService
    {
        private readonly IPresupuestoRepository _presupuestoRepository;
        public PresupuestoService(IPresupuestoRepository presupuestoRepository) : base(presupuestoRepository)
        {
            _presupuestoRepository = presupuestoRepository;
        }

        public async Task<List<Presupuesto>> GetAlljobBudgetsAsync(int jobId)
        {
            return await _presupuestoRepository.GetAlljobBudgets(jobId);
        }
    }
}
