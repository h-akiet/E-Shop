using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models.Entities
{
    [Table("Orders")]
    public class Order
    {

        [Key]
        public int OrderId { get; set; }
        [Required]

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

    }
}
