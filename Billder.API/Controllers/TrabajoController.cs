using AutoMapper;
using Billder.API.DTOs.Request.TrabajoRequestDTOs;
using Billder.API.DTOs.Response.TrabajoResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Classes;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Billder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly ITrabajoService _trabajoService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public TrabajoController(ITrabajoService trabajoService, IAuthService authService, IMapper mapper)
        {
            _trabajoService = trabajoService;
            _authService = authService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("obtener-trabajos")]
        public async Task<IActionResult> GetJobs(int customerId)
        {

            if (customerId is 0) return BadRequest("No se encontraron trabajos ya que el cliente no existe.");

            List<Trabajo> jobs = await _trabajoService.GetAllCustomerJobsAsync(customerId);
            return Ok(jobs);
        }

        [Authorize]
        [HttpGet("obtener-trabajo/{id:int}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            Trabajo job = await _trabajoService.GetByIdAsync(id);

            return Ok(job);
        }

        [Authorize]
        [HttpPost("crear-trabajo")]
        public async Task<IActionResult> CreateJob(TrabajoRequestDto trabajoRequestDto)
        {
            string authorizationHeader = Request.Headers["Authorization"].ToString();
            string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            int userId = int.Parse(userIdObtainedString);

            Trabajo jobToCreate = _mapper.Map<Trabajo>(trabajoRequestDto);
            jobToCreate.UsuarioId = userId;
            Trabajo createdJob = await _trabajoService.Create(jobToCreate);
            TrabajoResponseDto trabajoResponse = _mapper.Map<TrabajoResponseDto>(createdJob);

            return Ok(trabajoResponse);
        }

        [Authorize]
        [HttpPut("actualizar-trabajo/{id:int}")]
        public async Task<IActionResult> UpdateJob(int id, TrabajoRequestDto trabajoRequestDto)
        {
            string authorizationHeader = Request.Headers["Authorization"].ToString();
            string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            int userId = int.Parse(userIdObtainedString);

            Trabajo existingJob = await _trabajoService.GetByIdAsync(id);

            if (existingJob is null) return BadRequest("El trabajo que desea actualizar no existe.");

            _mapper.Map(trabajoRequestDto, existingJob);
            Trabajo updatedJob = await _trabajoService.Update(existingJob.Id, existingJob);

            TrabajoResponseDto trabajoResponse = _mapper.Map<TrabajoResponseDto>(updatedJob);

            return Ok(trabajoResponse);
        }
    }
}
