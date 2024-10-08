namespace Billder.API.Models
{
    public class Usuario : BaseModel
    {
        public string FullName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        //Navigation Properties
        public List<Trabajo>? Trabajo { get; set; }
    }
}
