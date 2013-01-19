using System;

namespace Architecture.Domain
{
    interface IArtist
    {
        int ArtistId { get; set; }
        string Name { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
