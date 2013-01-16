using System.Collections.Generic;
using Architecture.Website.Models;

namespace Architecture.Website.Services
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAlbums();
        IEnumerable<Album> GetRandomAlbumListing(int count = 10);
        Album GetAlbumById(int id);
        Album CreateAlbum(Album album);
        Album UpdateAlbum(Album album);
        bool DeleteAlbum(int id);
    }
}
