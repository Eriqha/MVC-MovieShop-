using System.ComponentModel.DataAnnotations;

namespace MVC_MovieShop_.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string? Director { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
