using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal DiscountValue { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int? UsageLimit { get; set; }

        [Required]
        public PromotionStatus Status { get; set; }  // Có thể dùng Enum nếu có nhiều trạng thái

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
