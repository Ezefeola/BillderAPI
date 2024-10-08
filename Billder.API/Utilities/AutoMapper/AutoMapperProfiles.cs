using AutoMapper;
using Billder.API.DTOs.Request.AuthRequestDtos;
using Billder.API.Models;

namespace Billder.API.Utilities.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterRequestDto, Usuario>();
            //CreateMap<ActualizarGeneroDTO, >();
            //CreateMap<Genero, GeneroDTO>();
        }
    }
}
