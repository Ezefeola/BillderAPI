namespace Billder.API.Models
{
    public class Presupuesto : BaseModel
    {
        public int TrabajoId { get; set; }
        public decimal Total { get; set; }

        public Trabajo? Trabajo { get; set; }
        public  List<Gasto>? Gastos { get; set; }
    }
}
