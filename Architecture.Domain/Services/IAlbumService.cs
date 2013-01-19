using System.Collections.Generic;

namespace Architecture.Domain
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAlbums();
        IEnumerable<Album> GetRandomAlbumListing(int count = 10);
        Album GetAlbumById(int id = 0);
        void CreateAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(int id = 0);
    }
}
