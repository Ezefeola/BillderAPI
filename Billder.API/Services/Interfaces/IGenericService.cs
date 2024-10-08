using Billder.API.Models;
using System.Linq.Expressions;

namespace Billder.API.Services.Interfaces
{
    public interface IGenericService<T> where T : BaseModel
    {
        Task<T> Create(T model);
        Task<T> Delete(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> Update(int id, T model);
    }
}
