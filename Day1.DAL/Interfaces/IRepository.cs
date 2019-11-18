using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

    }
}
