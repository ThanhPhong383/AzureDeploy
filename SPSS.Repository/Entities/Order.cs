using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Promotion")]
        public int PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; } = string.Empty;
        public virtual AppUser? AppUser { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public int ItemsCount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart? Cart { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual Payment? Payment { get; set; }


    }
}
