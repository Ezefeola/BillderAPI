namespace Billder.API.DTOs.Response.TrabajoResponseDTOs
{
    public class TrabajoResponseDto
    {
        public int ClienteId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = default!;
    }
}
