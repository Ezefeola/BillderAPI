﻿using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Repositories.Classes
{
    public class AuthRepository : GenericRepository<Usuario>, IAuthRepository
    {
        public AuthRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Usuario>> GetAllUsersWithRelations()
        {
            return await _dbSet.Include(x => x.Trabajo!).ThenInclude(x => x.Cliente).ToListAsync();
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            var emailExists = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

            return emailExists!;
        }

        public async Task<Usuario> DeleteUserWithRelations(int id)
        {
            var recordToDelete = await GetById(id);

            if (recordToDelete is null) throw new Exception("El registro no se encontro");

            await _dbSet.Where(x => x.Id == id).Include(x => x.Trabajo!).ThenInclude(x => x.Cliente).ExecuteDeleteAsync();

            return recordToDelete;
        }

        public async Task<Usuario> AuthenticateUser(string email, string password)
        {
            var userToAuthenticate = await _dbSet.FirstOrDefaultAsync(u => u.Email == email);

            if (userToAuthenticate is null) throw new Exception("Ha habido un error, verifique los campos e intentelo nuevamente");

            return userToAuthenticate;
        }

        public async Task<bool> VerifyEmailExists(string email)
        {
            var userCredentialsExist = await _dbSet.AnyAsync(u => u.Email == email);

            return userCredentialsExist;
        }

        public async Task<bool> VerifyDniExists(string dni)
        {
            var userDniExist = await _dbSet.AnyAsync(u => u.DNI == dni);

            return userDniExist;
        }
    }
}
