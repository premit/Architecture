using System;

namespace Architecture.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        void Rollback();
    }
}
