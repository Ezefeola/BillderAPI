namespace Billder.API.DTOs.Response.AuthResponseDTOs
{
    public class LoggedInUserInfoResponseDto
    {
        public string FullName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
