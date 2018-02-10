using Microsoft.EntityFrameworkCore;
using Mts.Core.Interface.Entity;
using Mts.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Mts.Infrastructure.Data.Repository
{
    public class CrudRepository<T> where T : class, IAuditDate
    {
        private readonly MtsContext _entities;

        public MtsContext Context
        {
            get
            {
                return _entities;
            }
        }

        public CrudRepository(MtsContext entities)
        {
            _entities = entities;
        }

        public async Task<T> Get(int id)
        {
            return await _entities.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> List()
        {
            return _entities.Set<T>().AsQueryable();
        }

        public IEnumerable<T> List(Func<T, bool> predicate)
        {
            return _entities.Set<T>().AsQueryable().Where(predicate);
        }

        public async Task Save(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.Today;
            _entities.Entry(entity).State = EntityState.Added;
            await _entities.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entity.UpdatedDate = DateTime.Today;
            _entities.Entry(entity).State = EntityState.Modified;
            await _entities.SaveChangesAsync();
        }
    }
}
