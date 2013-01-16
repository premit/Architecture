using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Architecture.Website.Models
{
    public interface IEntitiesContext
    {
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Album> Albums { get; set; }

        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
