using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Repository.Base
{
    public interface IRepository<T> where T : IEntity
    {
        public void Add(T item);
        public void AddRange(IEnumerable<T> items);

        public IEnumerable<T> Find(Func<T, bool> predicate);

        public T Get(int id);
        public IEnumerable<T> GetAll();

        public void Update(T item);
        public void UpdateRange(IEnumerable<T> items);
        public void Remove(T item);
        public void RemoveRange(IEnumerable<T> items);
    }
}
