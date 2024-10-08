using AutoMapper;
using Billder.API.DTOs.Request.ClienteRequestDTOs;
using Billder.API.DTOs.Response.ClienteResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Billder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IAuthService authService, IMapper mapper)
        {
            _clienteService = clienteService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("crear-cliente")]
        public async Task<IActionResult> CreateClient(ClienteRequestDto clienteRequestDto)
        {
            string authorizationHeader = Request.Headers["Authorization"].ToString();
            string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            int userId = int.Parse(userIdObtainedString);

            Cliente clientToCreate = _mapper.Map<Cliente>(clienteRequestDto);
            clientToCreate.UsuarioId = userId;
            Cliente createdClient = await _clienteService.Create(clientToCreate);
            ClienteResponseDto clienteResponseDto = _mapper.Map<ClienteResponseDto>(createdClient);

            return Ok(clienteResponseDto);
        }
    }
}
