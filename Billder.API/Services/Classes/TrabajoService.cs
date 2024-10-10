using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;
using Microsoft.Identity.Client;

namespace Billder.API.Services.Classes
{
    public class TrabajoService : GenericService<Trabajo> , ITrabajoService
    {
        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository) : base(trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        public async Task<List<Trabajo>> GetAllCustomerJobsAsync(int customerId)
        {
            return await _trabajoRepository.GetAllCustomerJobs(customerId);
        }
    }
}
