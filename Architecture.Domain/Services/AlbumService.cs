using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Architecture.Domain
{
    public class AlbumService : IAlbumService
    {
        private IUnitOfWork _uow;
        private IRepository<Album> _albumRepo;

        public AlbumService(
                IUnitOfWork uow,
                IRepository<Album> albumSvc
            )
        {
            if (uow == null)
                throw new ArgumentNullException("uow");
            if (albumSvc == null)
                throw new ArgumentNullException("albumSvc");

            _uow = uow;
            _albumRepo = albumSvc;
        }

        public IEnumerable<Album> GetAlbums()
        {
            var albums = _albumRepo.FindAll()
                .Include(a => a.Genre)
                .OrderBy(a => new { GenreName = a.Genre.Name, ArtistName = a.Artist.Name, a.Title }) // Sort by genre name, artist name, album title
                .ToList();

            return albums;
        }

        public IEnumerable<Album> GetRandomAlbumListing(int count = 10)
        {
            var albums = GetAlbums().OrderBy(a => Guid.NewGuid())
                .Take(count)
                .DefaultIfEmpty();

            return albums;
        }

        public Album GetAlbumById(int id = 0)
        {
            var album = _albumRepo.FindById(id);

            if (album == null)
                throw new NullReferenceException("Album does not exist.");

            return album;
        }

        public void CreateAlbum(Album album)
        {
            album.CreatedTime = DateTime.UtcNow;
            _albumRepo.Create(album);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to create album.");
        }

        public void UpdateAlbum(Album album)
        {
            album.UpdatedTime = DateTime.UtcNow;
            _albumRepo.Update(
                album,
                a => a.GenreId,
                a => a.ArtistId,
                a => a.Title,
                a => a.Price,
                a => a.AlbumArtUrl,
                a => a.UpdatedTime
            );

            if (_uow.Commit() < 1)
                throw new Exception("Failed to update genre.");
        }

        public void DeleteAlbum(int id)
        {
            _albumRepo.Delete(id);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to delete genre.");
        }
    }
}
