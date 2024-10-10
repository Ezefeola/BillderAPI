using AutoMapper;
using Billder.API.DTOs.Request.AuthRequestDTOs;
using Billder.API.DTOs.Response.AuthResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Classes;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, ITokenService tokenService, IMapper mapper)
        {
            _authService = authService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Usuario userToRegister = _mapper.Map<Usuario>(registerRequestDto);

                bool emailExists = await _authService.VerifyEmailExistsAsync(userToRegister.Email);
                if (emailExists) return BadRequest("Este email ya se encuentra registrado, intente con otro");

                bool dniExists = await _authService.VerifyDniExistsAsync(userToRegister.DNI);
                if (dniExists) return BadRequest("El dni ya se encuentra registrado");

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

                string token = _tokenService.CreateToken(logUser);
                LoginResponseDto loginResponseDto = _mapper.Map<LoginResponseDto>(logUser);

                loginResponseDto.Token = token;

                return Ok(loginResponseDto);
            }
            catch (Exception ex)
            {
                return Unauthorized("Las credenciales no son válidas.");
            }
        }

        [HttpGet("obtener-informacion-usuario")]
        public async Task<IActionResult> GetUserById()
        {
            string authorizationHeader = Request.Headers["Authorization"].ToString();
            string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            int userId = int.Parse(userIdObtainedString);

            Usuario loggedInUserInfo = await _authService.GetByIdAsync(userId);

            LoggedInUserInfoResponseDto loggedInUserInfoResponseDto = _mapper.Map<LoggedInUserInfoResponseDto>(loggedInUserInfo);

            return Ok(loggedInUserInfoResponseDto);
        }
    }
}
