using AutoMapper;
using Billder.API.DTOs.Request.AuthRequestDTOs;
using Billder.API.DTOs.Response.AuthResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Usuario userToRegister = _mapper.Map<Usuario>(registerRequestDto);

                Usuario registeredUser = await _authService.RegisterUserAsync(userToRegister);

                if (registeredUser is null) BadRequest("El usuario es nulo " + registeredUser);

                RegisterResponseDto registerResponseDto = _mapper.Map<RegisterResponseDto>(registeredUser);

                return Ok(registerResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Usuario userToLogin = _mapper.Map<Usuario>(loginRequestDto);

                Usuario logUser = await _authService.AuthenticateAsync(userToLogin.Email, userToLogin.Password);

                LoginResponseDto loginResponseDto = _mapper.Map<LoginResponseDto>(logUser);

                return Ok(loginResponseDto);
            }
            catch (Exception ex)
            {
                return Unauthorized("Las credenciales no son válidas.");
            }
        }
    }
}
