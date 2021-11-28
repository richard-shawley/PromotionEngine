using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Persistence
{
    public class InMemoryRepository<T>
    {
        private readonly ConcurrentBag<T> _entities = new ConcurrentBag<T>();

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
            => _entities;

        public IQueryable<T> Query()
            => _entities.AsQueryable();
    }
}
