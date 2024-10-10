namespace Billder.API.DTOs.Request.PresupuestoRequestDTOs
{
    public class GastoRequestDto
    {
        public int PresupuestoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; } = default!;
    }
}
