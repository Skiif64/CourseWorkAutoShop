using Shop.Data.Entities.Base;
using Shop.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ShopContext _db;

        public Repository(ShopContext db)
        {
            _db = db;
        }
        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item), "Сущность равна Null");
            _db.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items is null) throw new ArgumentNullException(nameof(items), "Сущности равны Null");
            _db.AddRange(items);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _db.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public void Remove(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item), "Сущность равна Null");
            _db.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _db.Set<T>().RemoveRange(items);
        }

        public void Update(T item)
        {
            _db.Set<T>().Update(item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            if (items is null) throw new ArgumentNullException(nameof(items), "Сущности равны Null");
            _db.Set<T>().UpdateRange(items);
        }
    }
}
