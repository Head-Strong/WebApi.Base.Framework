using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Repository.Interface
{
    public interface IRepository<T>
    {
        T SaveEntity(T entity);

        IEnumerable<T> GetEntities();

        void DeleteEntity(int id);

        Task<T> SaveEntityAsync(T entity);

        Task<IEnumerable<T>> GetEntitiesAsync();

        Task DeleteEntityAsync(int id);
    }
}
