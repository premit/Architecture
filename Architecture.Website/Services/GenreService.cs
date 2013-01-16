using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork<Genre> _genreUow;

        public GenreService(
                IUnitOfWork<Genre> genreUow
            )
        {
            _genreUow = genreUow;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = _genreUow.GenreRepository.FindAll()
                .OrderBy(g => g.Name)
                .ToList();

            return genres;
        }

        public Genre GetGenreById(int id)
        {
            var genre = _genreUow.GenreRepository.Find(id);

            if (genre == null)
            {
                throw new NullReferenceException("Genre does not exist.");
            }

            return genre;
        }

        public Genre CreateGenre(Genre genre)
        {
            genre.CreatedTime = DateTime.UtcNow;
            var newGenre = _genreUow.GenreRepository.Create(genre);

            var artist = new Artist
            {
                Name = "Test Artist A",
                CreatedTime = DateTime.UtcNow
            };
            _genreUow.ArtistRepository.Create(artist);

            _genreUow.Commit();

            if (newGenre == null)
            {
                throw new Exception("Failed to create genre.");
            }

            return genre;
        }

        public Genre UpdateGenre(Genre genre)
        {
            genre.UpdatedTime = DateTime.UtcNow;
            _genreUow.GenreRepository.Update(
                genre,
                g => g.Name,
                g => g.UpdatedTime
            );
            ;

            if (_genreUow.Commit() < 1)
            {
                throw new Exception("Failed to update genre.");
            }

            return genre;
        }

        public bool DeleteGenre(int id)
        {
            return _genreUow.GenreRepository.Delete(id);
        }
    }
}