using Inspector.Domain.Models;
using System.Collections.Generic;

namespace Inspector.DAL.Interfaces
{
    public interface IRepository<T> where T : new()
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
