using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Billder.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Billder.API.Services.Classes
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            
            _passwordHasher = new PasswordHasher<Usuario>();
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
        //public async Task<List<Usuario>> GetAllUsersWithRelationsAsync()
        //{
        //    var users = await _authRepository.GetAllUsersWithRelations();

        //    return users;
        //}

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _authRepository.GetUserByEmail(email);
        }

        public async Task<Usuario> DeleteUserWithRelationsAsync(int id)
        {
            var deletedUser = await _authRepository.DeleteUserWithRelations(id);

            return deletedUser;
        }

        public async Task<Usuario> RegisterUserAsync(Usuario usuario)
        {
            usuario.Password = _passwordHasher.HashPassword(usuario, usuario.Password);

            var nuevoUsuario = await _authRepository.Create(usuario);

            if (nuevoUsuario.Id <= 0)
            {
                throw new Exception("El ID del usuario no es válido después de la creación.");
            }

            string userToken = _tokenService.CreateToken(nuevoUsuario);
            return nuevoUsuario;

        }

        public async Task<Usuario> AuthenticateAsync(string email, string password)
        {
            Usuario userInDb = await _authRepository.GetUserByEmail(email);

            PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(userInDb, userInDb.Password, password);

            if (passwordVerification == PasswordVerificationResult.Failed) throw new Exception("Las credenciales no son correctas");

            Usuario user = await _authRepository.AuthenticateUser(email, password);

            string token = _tokenService.CreateToken(user);

            return user;
        }

        public async Task<string> GetUserIdByTokenAsync(string token)
        {
            string cleanToken = token.StartsWith("Bearer ") ? token.Substring("Bearer ".Length) : token;

            if (string.IsNullOrWhiteSpace(cleanToken))
            {
                throw new Exception("Token nulo o vacío.");
            }

            string decodedToken = await _tokenService.DecodeToken(cleanToken!);

            return decodedToken;
        }
    }
}
