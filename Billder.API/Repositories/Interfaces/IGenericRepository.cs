using Billder.API.Models;
using System.Linq.Expressions;

namespace Billder.API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAll();
        //Task<List<T>> GetAllWithPagination(PaginationDto paginationDto);
        Task<T> GetById(int id);
        Task<T> Create(T model);
        Task<T> Update(int id, T model);
        Task<T> Delete(int id);
    }
}
