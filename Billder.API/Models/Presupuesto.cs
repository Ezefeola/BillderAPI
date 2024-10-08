namespace Billder.API.Models
{
    public class Presupuesto : BaseModel
    {
        public string Materiales { get; set; } = default!;
        public int TrabajoId { get; set; }
        public decimal ManoDeObra { get; set; }
        public decimal PrecioMateriales { get; set; }
        public decimal Total { get; set; }

        public Trabajo? Trabajo { get; set; }
    }
}
