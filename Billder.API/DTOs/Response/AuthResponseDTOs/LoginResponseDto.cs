﻿namespace Billder.API.DTOs.Response.AuthResponseDTOs
{
    public class LoginResponseDto
    {
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
