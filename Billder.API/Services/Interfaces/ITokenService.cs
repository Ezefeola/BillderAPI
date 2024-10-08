using Billder.API.Models;

namespace Billder.API.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
        Task<string> DecodeToken(string token);
    }
}
