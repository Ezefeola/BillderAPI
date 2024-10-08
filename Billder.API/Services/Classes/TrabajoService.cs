using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;

namespace Billder.API.Services.Classes
{
    public class TrabajoService : GenericService<Trabajo> , ITrabajoService
    {
        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository) : base(trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }
    }
}
