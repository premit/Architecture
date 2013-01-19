using System.Collections.Generic;

namespace Architecture.Domain
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetArtists();
        Artist GetArtistById(int id = 0);
        void CreateArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(int id = 0);
    }
}
