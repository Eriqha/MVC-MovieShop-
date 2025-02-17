using System.ComponentModel.DataAnnotations;

namespace MVC_MovieShop_.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Address { get; set; }

        public ICollection<RentalHeader>? RentalHeaders { get; set; } = new List<RentalHeader>();
    }
}
