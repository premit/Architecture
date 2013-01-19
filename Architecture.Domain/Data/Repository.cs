using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Architecture.Domain
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IEntitiesContext _context;

        public Repository(
            IEntitiesContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Set<TEntity>()
                .Add(entity);
        }

        public TEntity FindById(int id = 0)
        {
            return _context.Set<TEntity>()
                .Find(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Set<TEntity>()
                .Attach(entity);
            DbEntityEntry<TEntity> entry = _context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        public void Delete(int id = 0)
        {
            var entity = FindById(id);

            _context.Set<TEntity>()
                .Remove(entity);
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