﻿using Billder.API.Data;
using Billder.API.Models;
using Billder.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected DbSet<T> _dbSet;
        protected DbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        //public virtual async Task<List<T>> GetAllWithPagination(PaginationDto paginationDto)
        //{
        //    var recordsQueriable = _dbContext.Set<T>().AsQueryable();

        //    return await recordsQueriable.Paginate(paginationDto).ToListAsync();
        //}

        public async Task<T> GetById(int id)
        {
            var recordDb = await _dbSet.FindAsync(id);
            if (recordDb is null) throw new Exception($"No se encontro el ID: {id}");
            return recordDb;
        }

        public virtual async Task<T> Create(T model)
        {
            _dbSet.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
        public async Task<T> Update(int id, T model)
        {
            model.Id = id;

            _dbSet.Update(model);

            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<T> Delete(int id)
        {
            var recordToDelete = await GetById(id);

            if (recordToDelete is null) throw new Exception("El registro no se encontro");

            await _dbSet.Where(x => x.Id == id).ExecuteDeleteAsync();

            return recordToDelete;
        }
    }
}

