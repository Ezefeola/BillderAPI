namespace Billder.API.DTOs.Request.ClienteRequestDTOs
{
    public class ClienteRequestDto
    {
        public string Dni { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string? Descripcion { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public DateTime? FechaAlta { get; set; }

    }
}
