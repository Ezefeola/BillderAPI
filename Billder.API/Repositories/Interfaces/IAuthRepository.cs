using Billder.API.Models;

namespace Billder.API.Repositories.Interfaces
{
    public interface IAuthRepository : IGenericRepository<Usuario>
    {
        //Task<List<Usuario>> GetAllUsersWithRelations();
        Task<Usuario> DeleteUserWithRelations(int id);
        Task<Usuario> GetUserByEmail(string email);
        Task<Usuario> AuthenticateUser(string email, string password);
    }
}
