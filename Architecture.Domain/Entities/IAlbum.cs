using System;

namespace Architecture.Domain
{
    interface IAlbum
    {
        int AlbumId { get; set; }
        int GenreId { get; set; }
        int ArtistId { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        string AlbumArtUrl { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
