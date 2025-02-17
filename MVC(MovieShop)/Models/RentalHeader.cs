using System.ComponentModel.DataAnnotations;

namespace MVC_MovieShop_.Models
{
    public class RentalHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? CustomerDetails { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
    }
}
