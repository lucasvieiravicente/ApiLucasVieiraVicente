using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.Repository.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(Guid id);
    }
}
