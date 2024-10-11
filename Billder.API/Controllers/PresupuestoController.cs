using AutoMapper;
using Billder.API.DTOs.Request.PresupuestoRequestDTOs;
using Billder.API.DTOs.Request.TrabajoRequestDTOs;
using Billder.API.DTOs.Response.PresupuestoResponseDTOs;
using Billder.API.DTOs.Response.TrabajoResponseDTOs;
using Billder.API.Models;
using Billder.API.Services.Classes;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("obtener-presupuestos")]
        public async Task<IActionResult> GetBudgets(int budgetId)
        {
            List<Presupuesto> budgets = await _presupuestoService.GetAlljobBudgetsAsync(budgetId);
            return Ok(budgets);
        }

        [Authorize]
        [HttpGet("obtener-presupuesto/{id:int}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            Presupuesto budget = await _presupuestoService.GetByIdAsync(id);

            return Ok(budget);
        }

        [Authorize]
        [HttpPost("crear-presupuesto")]
        public async Task<IActionResult> CreateBudget(PresupuestoRequestDto presupuestoRequestDto)
        {
            try
            {
                Presupuesto budgetToCreate = _mapper.Map<Presupuesto>(presupuestoRequestDto);

                List<Gasto> gastosToCreate = _mapper.Map<List<Gasto>>(presupuestoRequestDto.Gastos);

                decimal precioTotal = gastosToCreate.Sum(gasto => gasto.Precio * gasto.Cantidad);
                budgetToCreate.Total = precioTotal;

                budgetToCreate.Gastos = gastosToCreate;

                Presupuesto createdBudget = await _presupuestoService.Create(budgetToCreate);

                PresupuestoResponseDto presupuestoResponseDto = _mapper.Map<PresupuestoResponseDto>(createdBudget);

                return Ok(presupuestoResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo crear el presupuesto" + ex);
            }
        }

        //[Authorize]
        //[HttpPost("crear-gastos")]
        //public async Task<IActionResult> CreateExpense(List<GastoRequestDto> gastoRequestDto, int id)
        //{
        //    try
        //    {
        //        Presupuesto budget = await _presupuestoService.GetByIdAsync(id);

        //        List<Gasto> gastosToCreate = _mapper.Map<List<Gasto>>(gastoRequestDto);

        //        decimal precio = 0;
        //        foreach (var item in gastosToCreate)
        //        {
        //            precio += item.Precio * item.Cantidad;
        //        }
        //        budget.Total += precio;

        //        gastosToCreate.Select(x => x.Id = id);
        //        await _presupuestoService.CreateGastosAsync(gastosToCreate);

        //        PresupuestoResponseDto presupuestoResponseDto = _mapper.Map<PresupuestoResponseDto>(budget);

        //        return Ok(presupuestoResponseDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("No se pudo crear el presupuesto" + ex);
        //    }
        //}


        [Authorize]
        [HttpPut("actualizar-presupuesto/{id:int}")]
        public async Task<IActionResult> UpdateBudget(int id, PresupuestoRequestDto presupuestoRequestDto)
        {
            //string authorizationHeader = Request.Headers["Authorization"].ToString();
            //string userIdObtainedString = await _authService.GetUserIdByTokenAsync(authorizationHeader);
            //int userId = int.Parse(userIdObtainedString);

            Presupuesto existingBudget = await _presupuestoService.GetByIdAsync(id);

            if (existingBudget is null) return BadRequest("El presupuesto que desea actualizar no existe.");

            _mapper.Map(presupuestoRequestDto, existingBudget);
            Presupuesto updatedBudget = await _presupuestoService.Update(existingBudget.Id, existingBudget);

            PresupuestoResponseDto presupuestoResponse = _mapper.Map<PresupuestoResponseDto>(updatedBudget);

            return Ok(presupuestoResponse);
        }
    }
}
