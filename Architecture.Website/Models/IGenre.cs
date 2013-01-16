using System;

namespace Architecture.Website.Models
{
    interface IGenre
    {
        int GenreId { get; set; }
        string Name { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
