using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Core.Interface.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        Task Save(T entity);
        Task Update(T entity);
        T Get(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> predicate);
    }
}
