using AutoMapper;
using Billder.API.DTOs.Request.TrabajoRequestDTOs;
using Billder.API.DTOs.Response.TrabajoResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Interfaces;
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

        [HttpPost("crear-trabajo")]
        public async Task<IActionResult> CreateJob(TrabajoRequestDto trabajoRequestDto)
        {
            //string authorizationHeader = Request.Headers["Authorization"].ToString();
            //string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            //int userId = int.Parse(userIdObtainedString);

            Trabajo jobToCreate = _mapper.Map<Trabajo>(trabajoRequestDto);

            Trabajo createdJob = await _trabajoService.Create(jobToCreate);

            TrabajoResponseDto trabajoResponse = _mapper.Map<TrabajoResponseDto>(createdJob);

            return Ok(trabajoResponse);
        }
    }
}
