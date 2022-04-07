using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
