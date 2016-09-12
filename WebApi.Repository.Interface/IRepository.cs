using System.Collections.Generic;

namespace WebApi.Repository.Interface
{
    public interface IRepository<T>
    {
        T SaveEntity(T entity);

        IEnumerable<T> GetEntities();

        void DeleteEntity(int id);
    }
}
