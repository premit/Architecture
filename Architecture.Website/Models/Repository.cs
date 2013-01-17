using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Architecture.Website.Models
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IEntitiesContext _context;

        public Repository(
            IEntitiesContext context)
        {
            _context = context;
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>()
                .Add(entity);

            //Save();

            return entity;
        }

        public TEntity Find(int id)
        {
            return _context.Set<TEntity>()
                .Find(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;

            //Save();

            return entity;
        }

        public bool Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            _context.Set<TEntity>()
                .Attach(entity);
            DbEntityEntry<TEntity> entry = _context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }

            //return Save() > 0 ? true : false;

            return true;
        }

        public bool Delete(int id)
        {
            var entity = Find(id);

            _context.Set<TEntity>()
                .Remove(entity);

            //return Save() > 0 ? true : false;
            return true;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        // Dispose object
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}