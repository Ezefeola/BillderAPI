using AutoMapper;
using Billder.API.DTOs.Request.PresupuestoRequestDTOs;
using Billder.API.DTOs.Response.PresupuestoResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoService _presupuestoService;
        private readonly IMapper _mapper;

        public PresupuestoController(IPresupuestoService presupuestoService, IMapper mapper)
        {
            _presupuestoService = presupuestoService;
            _mapper = mapper;
        }

        [HttpGet("obtener-presupuestos")]
        public async Task<IActionResult> GetBudgets()
        {
            List<Presupuesto> budgets = await _presupuestoService.GetAllAsync();
            return Ok(budgets);
        }

        [HttpPost("crear-presupuesto")]
        public async Task<IActionResult> CreateBudget(PresupuestoRequestDto presupuestoRequestDto)
        {
            try
            {
                Presupuesto budgetToCreate = _mapper.Map<Presupuesto>(presupuestoRequestDto);
                budgetToCreate.Total = budgetToCreate.PrecioManoDeObra + budgetToCreate.PrecioMateriales;
                Presupuesto createdBudget = await _presupuestoService.Create(budgetToCreate);

                PresupuestoResponseDto presupuestoResponseDto = _mapper.Map<PresupuestoResponseDto>(createdBudget);

                return Ok(presupuestoResponseDto);
            }
            catch (Exception)
            {

                return BadRequest("No se pudo crear el presupuesto");
            }
        }
    }
}
