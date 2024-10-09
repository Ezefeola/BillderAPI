using AutoMapper;
using Billder.API.DTOs.Request.ClienteRequestDTOs;
using Billder.API.DTOs.Response.ClienteResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("obtener-clientes")]
        public async Task<IActionResult> GetCustomers()
        {
            List<Cliente> customers = await _clienteService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("obtener-cliente/{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            Cliente customer = await _clienteService.GetByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost("crear-cliente")]
        public async Task<IActionResult> CreateCustomer(ClienteRequestDto clienteRequestDto)
        {
            string authorizationHeader = Request.Headers["Authorization"].ToString();
            string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            int userId = int.Parse(userIdObtainedString);

            Cliente customerToCreate = _mapper.Map<Cliente>(clienteRequestDto);
            customerToCreate.UsuarioId = userId;
            Cliente createdClient = await _clienteService.Create(customerToCreate);
            ClienteResponseDto clienteResponseDto = _mapper.Map<ClienteResponseDto>(createdClient);

            return Ok(clienteResponseDto);
        }

        [Authorize]
        [HttpPut("actualizar-cliente/{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, ClienteRequestDto clienteRequestDto)
        {
            //string authorizationHeader = Request.Headers["Authorization"].ToString();
            //string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            //int userId = int.Parse(userIdObtainedString);

            Cliente existingCustomer = await _clienteService.GetByIdAsync(id);

            if (existingCustomer is null) return BadRequest("El presupuesto que desea actualizar no existe.");

            _mapper.Map(clienteRequestDto, existingCustomer);
            Cliente updatedCustomer = await _clienteService.Update(existingCustomer.Id, existingCustomer);

            ClienteResponseDto clienteResponse = _mapper.Map<ClienteResponseDto>(updatedCustomer);

            return Ok(clienteResponse);
        }
    }
}
