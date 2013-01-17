using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public class ArtistService : IArtistService
    {
        private IUnitOfWork _uow;
        private IRepository<Artist> _artistRepo;

        public ArtistService(
                IUnitOfWork uow,
                IRepository<Artist> artistRepo
            )
        {
            _uow = uow;
            _artistRepo = artistRepo;
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _artistRepo.FindAll()
                .OrderBy(a => a.Name)
                .ToList();
        }

        public Artist GetArtistById(int id)
        {
            var artist = _artistRepo.Find(id);

            if (artist == null)
            {
                throw new NullReferenceException("Artist does not exist.");
            }

            return artist;
        }

        public Artist CreateArtist(Artist artist)
        {
            artist.CreatedTime = DateTime.UtcNow;
            artist = _artistRepo.Create(artist);
            _uow.Commit();

            if (artist == null)
            {
                throw new Exception("Failed to create artist.");
            }

            return artist;
        }

        public Artist UpdateArtist(Artist artist)
        {
            artist.UpdatedTime = DateTime.UtcNow;
            _artistRepo.Update(
                artist,
                a => a.Name,
                a => a.UpdatedTime
            );

            if (_uow.Commit() < 1)
            {
                throw new Exception("Failed to update artist.");
            }

            return artist;
        }

        public bool DeleteArtist(int id)
        {
            _artistRepo.Delete(id);
            return _uow.Commit() > 0 ? true : false;
        }
    }
}