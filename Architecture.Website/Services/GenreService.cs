using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork _uow;
        private IRepository<Genre> _genreRepo;
        private IRepository<Artist> _artistRepo;

        public GenreService(
                IUnitOfWork uow,
                IRepository<Genre> genreRepo,
                IRepository<Artist> artistRepo
            )
        {
            _uow = uow;
            _genreRepo = genreRepo;
            _artistRepo = artistRepo;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = _genreRepo.FindAll()
                .OrderBy(g => g.Name)
                .ToList();

            return genres;
        }

        public Genre GetGenreById(int id)
        {
            var genre = _genreRepo.Find(id);

            if (genre == null)
            {
                throw new NullReferenceException("Genre does not exist.");
            }

            return genre;
        }

        public Genre CreateGenre(Genre genre)
        {
            genre.CreatedTime = DateTime.UtcNow;
            var newGenre = _genreRepo.Create(genre);
            _uow.Commit();

            if (newGenre == null)
            {
                throw new Exception("Failed to create genre.");
            }

            return genre;
        }

        public Genre UpdateGenre(Genre genre)
        {
            genre.UpdatedTime = DateTime.UtcNow;
            _genreRepo.Update(
                genre,
                g => g.Name,
                g => g.UpdatedTime
            );
            ;

            if (_uow.Commit() < 1)
            {
                throw new Exception("Failed to update genre.");
            }

            return genre;
        }

        public bool DeleteGenre(int id)
        {
            _genreRepo.Delete(id);
            return _uow.Commit() > 0 ? true : false;
        }
    }
}