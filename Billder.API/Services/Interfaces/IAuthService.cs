using Billder.API.Models;

namespace Billder.API.Services.Interfaces
{
    public interface IAuthService : IGenericService<Usuario>
    {
        //Task<List<Usuario>> GetAllUsersWithRelationsAsync();
        Task<Usuario> DeleteUserWithRelationsAsync(int id);
        Task<Usuario> GetUserByEmailAsync(string email);
        Task<Usuario> AuthenticateAsync(string email, string password);
        Task<Usuario> RegisterUserAsync(Usuario usuario);
        Task<string> GetUserIdByTokenAsync(string token);
        Task<bool> VerifyEmailExistsAsync(string email);
        Task<bool> VerifyDniExistsAsync(string dni);
    }
}
