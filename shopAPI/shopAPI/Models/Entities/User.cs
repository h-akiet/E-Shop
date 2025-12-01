using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Fullname { get; set; } = null!;
    }
}
