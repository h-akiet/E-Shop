namespace ShopApi.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        required public string Username { get; set; }

        public string Email { get; set; } = null!;

        [Required]
        required public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Fullname { get; set; } = null!;
    }
}
