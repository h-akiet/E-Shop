using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string FullName { get; set; }
        public string Email { get; set; } = null!;
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string Address { get; set; } 
    }
}
