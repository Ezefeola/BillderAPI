namespace Billder.API.DTOs.Request.TrabajoRequestDTOs
{
    public class TrabajoRequestDto
    {
        public int ClienteId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = default!;
    }
}
