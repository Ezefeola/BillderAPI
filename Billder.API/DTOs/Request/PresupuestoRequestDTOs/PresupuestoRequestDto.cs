using Billder.API.Models;

namespace Billder.API.DTOs.Request.PresupuestoRequestDTOs
{
    public class PresupuestoRequestDto
    {
        public int TrabajoId { get; set; }
        public List<GastoRequestDto>? Gastos { get; set; }
    }
}