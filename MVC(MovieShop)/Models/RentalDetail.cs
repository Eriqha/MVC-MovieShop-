using System.ComponentModel.DataAnnotations;

namespace MVC_MovieShop_.Models
{
    public class RentalDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RentalHeaderId { get; set; }
        public RentalHeader? RentalHeader { get; set; }

        public string Status { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Required]
        public decimal RentalFee { get; set; }
    }
}
