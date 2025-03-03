using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSS.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public int ItemsCount { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
