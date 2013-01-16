using System;

namespace Architecture.Website.Models
{
    interface IArtist
    {
        int ArtistId { get; set; }
        string Name { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
