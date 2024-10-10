namespace Billder.API.Models
{
    public class Gasto : BaseModel
    {
        public  int PresupuestoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; } = default!;

        //Navigation Properties
        public Presupuesto? Presupuesto { get; set; }
    }
}
