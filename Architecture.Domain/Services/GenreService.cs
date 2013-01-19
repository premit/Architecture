using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Domain
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork _uow;
        private IRepository<Genre> _genreRepo;

        public GenreService(
                IUnitOfWork uow,
                IRepository<Genre> genreRepo
            )
        {
            if (uow == null)
                throw new ArgumentNullException("uow");
            if (genreRepo == null)
                throw new ArgumentNullException("genreRepo");

            _uow = uow;
            _genreRepo = genreRepo;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = _genreRepo.FindAll()
                .OrderBy(g => g.Name)
                .ToList();
            return genres;
        }

        public Genre GetGenreById(int id = 0)
        {
            var genre = _genreRepo.FindById(id);

            if (genre == null)
                throw new NullReferenceException("Genre does not exist.");

            return genre;
        }

        public void CreateGenre(Genre genre)
        {
            genre.CreatedTime = DateTime.UtcNow;
            _genreRepo.Create(genre);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to create genre.");
        }

        public void UpdateGenre(Genre genre)
        {
            genre.UpdatedTime = DateTime.UtcNow;
            _genreRepo.Update(
                genre,
                g => g.Name,
                g => g.UpdatedTime
            );
            ;

            if (_uow.Commit() < 1)
                throw new Exception("Failed to update genre.");
        }

        public void DeleteGenre(int id = 0)
        {
            _genreRepo.Delete(id);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to delete genre.");
        }
    }
}
