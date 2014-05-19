using Inspector.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inspector.DAL.Interfaces
{
    public interface IRepository<T> where T : IEntity, new()
    {
        void Add(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicat);
        void Update(T entity);
        void Delete(T entity);
    }
}
