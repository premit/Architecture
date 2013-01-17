using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Website.Models
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        void Rollback();
    }
}
