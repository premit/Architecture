﻿using System;

namespace Architecture.Domain
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IEntitiesContext _context;

        public UnitOfWork(
                IEntitiesContext context
            )
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
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
