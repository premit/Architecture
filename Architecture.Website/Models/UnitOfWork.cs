using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Architecture.Website.Models
{
    public class UnitOfWork<T> : /*DbContext, */ IUnitOfWork<T>, IDisposable
        where T : class
    {
        private readonly IRepository<Genre> _genreRepo;
        private readonly IRepository<Artist> _artistRepo;
        private readonly IEntitiesContext _context;

        public UnitOfWork(
                IEntitiesContext context
            )
        {
            _context = context;
            _genreRepo = new Repository<Genre>(_context);
            _artistRepo = new Repository<Artist>(_context);
        }

        public IRepository<Genre> GenreRepository
        {
            get { return _genreRepo; }
        }

        public IRepository<Artist> ArtistRepository
        {
            get { return _artistRepo; }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Rollback()
        {

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