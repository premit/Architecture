using System;

namespace Architecture.Domain
{
    interface IGenre
    {
        int GenreId { get; set; }
        string Name { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
