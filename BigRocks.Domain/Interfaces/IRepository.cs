using System;
using System.Collections.Generic;
using BigRocks.Domain.SharedKernel;

namespace BigRocks.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(Predicate<BaseEntity> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);
    }
}