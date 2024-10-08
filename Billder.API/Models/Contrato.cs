namespace Billder.API.Models
{
    public class Contrato : BaseModel
    {
        public int TrabajoId { get; set; }
        public string Cliente { get; set; } = default!;
        public string Condiciones { get; set; } = default!;
        public string FirmaDigital { get; set; } = default!;

        public Trabajo? Trabajo { get; set; }
    }
}
