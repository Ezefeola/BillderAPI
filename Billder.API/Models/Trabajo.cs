namespace Billder.API.Models
{
    public class Trabajo : BaseModel
    {
        public int ClienteId { get; set; } = default!;
        public int UsuarioId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = default!;

        public Presupuesto? Presupuesto { get; set; }
        public Contrato? Contrato { get; set; }
        public List<Pago>? Pago { get; set; }
        public Usuario? Usuario { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
