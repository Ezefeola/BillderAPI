using AutoMapper;
using Billder.API.DTOs.Request.AuthRequestDTOs;
using Billder.API.DTOs.Request.ClienteRequestDTOs;
using Billder.API.DTOs.Request.PresupuestoRequestDTOs;
using Billder.API.DTOs.Request.TrabajoRequestDTOs;
using Billder.API.DTOs.Response.AuthResponseDTOs;
using Billder.API.DTOs.Response.ClienteResponseDTOs;
using Billder.API.DTOs.Response.PresupuestoResponseDTOs;
using Billder.API.DTOs.Response.TrabajoResponseDTOs;
using Billder.API.Models;

namespace Billder.API.Utilities.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterRequestDto, Usuario>();
            CreateMap<Usuario, RegisterResponseDto>();

            CreateMap<LoginRequestDto, Usuario>();
            CreateMap<Usuario, LoginResponseDto>();

            CreateMap<PresupuestoRequestDto, Presupuesto>();
            CreateMap<Presupuesto, PresupuestoResponseDto>();

            CreateMap<TrabajoRequestDto, Trabajo>();
            CreateMap<Trabajo, TrabajoResponseDto>();

            CreateMap<ClienteRequestDto, Cliente>();
            CreateMap<Cliente, ClienteResponseDto>();

            CreateMap<Usuario, LoggedInUserInfoResponseDto>();
        }
    }
}
