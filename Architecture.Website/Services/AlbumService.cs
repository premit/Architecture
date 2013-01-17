using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Architecture.Website.Models;

namespace Architecture.Website.Services
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

        public Album GetAlbumById(int id)
        {
            var album = _albumRepo.Find(id);

            if (album == null)
            {
                throw new NullReferenceException("Album does not exist.");
            }

            return album;
        }

        public Album CreateAlbum(Album album)
        {
            album.CreatedTime = DateTime.UtcNow;
            album = _albumRepo.Create(album);
            _uow.Commit();

            if (album == null)
            {
                throw new Exception("Failed to create album.");
            }

            return album;
        }

        public Album UpdateAlbum(Album album)
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
            {
                throw new Exception("Failed to update genre.");
            }

            return album;
        }

        public bool DeleteAlbum(int id)
        {
            _albumRepo.Delete(id);
            return _uow.Commit() > 0 ? true : false;
        }
    }
}