using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Domain
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
            if (uow == null)
                throw new ArgumentNullException("uow");
            if (artistRepo == null)
                throw new ArgumentNullException("artistRepo");

            _uow = uow;
            _artistRepo = artistRepo;
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _artistRepo.FindAll()
                .OrderBy(a => a.Name)
                .ToList();
        }

        public Artist GetArtistById(int id = 0)
        {
            var artist = _artistRepo.FindById(id);

            if (artist == null)
                throw new NullReferenceException("Artist does not exist.");

            return artist;
        }

        public void CreateArtist(Artist artist)
        {
            artist.CreatedTime = DateTime.UtcNow;
            _artistRepo.Create(artist);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to create artist.");
        }

        public void UpdateArtist(Artist artist)
        {
            artist.UpdatedTime = DateTime.UtcNow;
            _artistRepo.Update(
                artist,
                a => a.Name,
                a => a.UpdatedTime
            );

            if (_uow.Commit() < 1)
                throw new Exception("Failed to update artist.");
        }

        public void DeleteArtist(int id = 0)
        {
            _artistRepo.Delete(id);

            if (_uow.Commit() < 1)
                throw new Exception("Failed to delete artist.");
        }
    }
}
