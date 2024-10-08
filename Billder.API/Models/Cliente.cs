namespace Billder.API.Models
{
    public class Cliente
    {
        public int UsuarioId { get; set; }
        public string Identificacion { get; set; } = null!;
        public string? NroIdentificacion { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public DateTime? FechaAlta { get; set; }

        public Usuario? Usuario { get; set; }
        public List<Trabajo>? Trabajos { get; set; }
    }
}
