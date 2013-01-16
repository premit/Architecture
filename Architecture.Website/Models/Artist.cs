using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Website.Models
{
    public class Artist : IArtist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        [StringLength(100, ErrorMessage = "Artist Name cannot be more than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public DateTime? UpdatedTime { get; set; }

        [ReadOnly(true)]
        public bool CanDelete { get; set; }
    }
}