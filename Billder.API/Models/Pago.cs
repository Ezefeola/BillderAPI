namespace Billder.API.Models
{
    public class Pago : BaseModel
    {
        public int TrabajoId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; } = default!;
        public DateTime FechaPago { get; set; }

        public Trabajo? Trabajo { get; set; }
    }
}
