using Billder.API.Models;

namespace Billder.API.DTOs.Request.PresupuestoRequestDTOs
{
    public class PresupuestoRequestDto
    {
        public string Materiales { get; set; } = default!;
        public int TrabajoId { get; set; }
        public string DescripcionManoDeObra { get; set; } = default!;
        public decimal PrecioManoDeObra { get; set; }
        public decimal PrecioMateriales { get; set; }
        public List<Gasto>? Gastos { get; set; }
    }
}
