using System;
using System.Linq;
using System.Linq.Expressions;

namespace Architecture.Domain
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        TEntity FindById(int id = 0);
        IQueryable<TEntity> FindAll();
        void Update(TEntity entity);
        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
        void Delete(int id = 0);
        int Save();
    }
}
