using System.Collections.Generic;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetArtists();
        Artist GetArtistById(int id);
        Artist CreateArtist(Artist artist);
        Artist UpdateArtist(Artist artist);
        bool DeleteArtist(int id);
    }
}
