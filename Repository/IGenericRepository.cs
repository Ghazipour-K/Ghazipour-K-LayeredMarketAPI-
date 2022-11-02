using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task DeleteAsync(object id);
        Task SaveAsync();
    }
}
