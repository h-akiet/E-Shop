namespace ShopApi.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        required public string FullName { get; set; }

        public string Email { get; set; } = null!;

        [Required]
        required public string Phone { get; set; }

        [Required]
        required public string Address { get; set; }
    }
}
