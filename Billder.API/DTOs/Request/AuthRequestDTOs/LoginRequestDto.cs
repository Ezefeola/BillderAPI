namespace Billder.API.DTOs.Request.AuthRequestDTOs
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
