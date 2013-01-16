using System.Collections.Generic;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int id);
        Genre CreateGenre(Genre genre);
        Genre UpdateGenre(Genre genre);
        bool DeleteGenre(int id);
    }
}
