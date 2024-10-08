namespace Billder.API.DTOs.Response.PresupuestoResponseDTOs
{
    public class PresupuestoResponseDto
    {
        public string Materiales { get; set; } = default!;
        public int TrabajoId { get; set; }
        public string DescripcionManoDeObra { get; set; } = default!;
        public decimal PrecioManoDeObra { get; set; }
        public decimal PrecioMateriales { get; set; }
        public decimal Total { get; set; }
    }
}
