using System;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Website.Models
{
    public class Genre : IGenre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Genre Name")]
        [StringLength(100, ErrorMessage = "Genre Name cannot be more than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Created On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Updated On")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        [ScaffoldColumn(false)]
        public DateTime? UpdatedTime { get; set; }
    }
}