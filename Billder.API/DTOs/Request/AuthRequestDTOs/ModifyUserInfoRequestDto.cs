namespace Billder.API.DTOs.Request.AuthRequestDTOs
{
    public class ModifyUserInfoRequestDto
    {
        public string FullName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
