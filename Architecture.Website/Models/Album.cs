using System;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Website.Models
{
    public class Album : IAlbum
    {
        [Key]
        public int AlbumId { get; set; }

        [Display(Name = "Genre Name")]
        public int GenreId { get; set; }

        [Display(Name = "Artist Name")]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Album Title")]
        [StringLength(255, ErrorMessage = "Album Title cannot be more than 255 characters.")]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [Display(Name = "Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        public DateTime CreatedTime { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        public DateTime? UpdatedTime { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}