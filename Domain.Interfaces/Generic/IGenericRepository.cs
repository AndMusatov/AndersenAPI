using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task Remove(T entity);
        Task<T> GetById(int id);
    }
}
