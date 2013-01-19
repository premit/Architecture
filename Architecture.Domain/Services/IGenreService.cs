using System.Collections.Generic;

namespace Architecture.Domain
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int id = 0);
        void CreateGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int id = 0);
    }
}
