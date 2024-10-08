using AutoMapper;
using Billder.API.DTOs.Request.AuthRequestDTOs;
using Billder.API.DTOs.Response.AuthResponseDTOs;
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
            //CreateMap<ActualizarGeneroDTO, >();
            //CreateMap<Genero, GeneroDTO>();
        }
    }
}
