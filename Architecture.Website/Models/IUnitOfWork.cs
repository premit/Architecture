using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Website.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Genre> GenreRepository { get; }
        IRepository<Artist> ArtistRepository { get; }
        IRepository<Album> AlbumRepository { get; }

        int Commit();
        void Rollback();
    }
}
