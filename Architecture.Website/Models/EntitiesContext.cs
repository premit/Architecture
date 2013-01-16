using System.Data.Entity;

namespace Architecture.Website.Models
{
    public class EntitiesContext : DbContext, IEntitiesContext
    {
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Album> Albums { get; set; }

        public EntitiesContext()
            : base("DefaultConnection")
        {
        }
    }
}